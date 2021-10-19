using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PSETIME_BACK.BussinessLogic.IService.UserManager;
using PSETIME_BACK.DAL.DAOs.IDAO.GlobalConfigs;
using PSETIME_BACK.DAL.DAOs.IDAO.UserManager;
using PSETIME_BACK.DAL.Models.Entities.UserManager;
using PSETIME_BACK.DTO.VBM.UserManager;
using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.UserManager;
using PSETIME_BACK.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PSETIME_BACK.BussinessLogic.ImplService.UserManager
{
    public class UsersServices : IUsersServices
    {

        /// <summary>
        ///  DI
        /// </summary>
        readonly UserManager<Users> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;
        readonly IConfiguration _configuration;
        readonly IUserGroupsDao _userGroupsDao;
        readonly IClaimsDao _claimsDao;
        readonly IUserSessionDao _userSessionDao;
        readonly IGlobalConfigsDao _globalConfigsDao;
        public UsersServices(UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IUserGroupsDao userGroupsDao, IGlobalConfigsDao globalConfigsDao, IUserSessionDao userSessionDao, IClaimsDao claimsDao)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _userGroupsDao = userGroupsDao;
            _claimsDao = claimsDao;
            _userSessionDao = userSessionDao;
            _globalConfigsDao = globalConfigsDao;
        }

        /// <summary>
        ///     create group and his configuration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Response<String> CreateGroups(GroupsVbm model)
        {
            String message = MsgUtils.OK;
            String stackTrace = String.Empty;


            try
            {

                using (TransactionScope scope = new TransactionScope())
                {
                    var config = model.ToEntity();
                    config.BaseCreate("1", true);
                    _globalConfigsDao.Insert(config);

                    if (config.Id <= 0)
                    {
                        return new Response<string>() { Message = MsgUtils.BAD_PARAMETERS, Success = false };
                    }

                    var group = model.ToEntity(config.Id);
                    group.BaseCreate("1", true);
                    _userGroupsDao.Insert(group);

                    scope.Complete();
                }
            }
            catch (Exception e)
            {
                message = e.StackTrace;
                if (e.InnerException != null)
                {
                    message = e.InnerException.Message;
                }

                stackTrace = e.StackTrace;

            }

            return new Response<String>() { Data = message, Total = 1, Success = message.Equals(MsgUtils.OK), Message = message, StackTrace = stackTrace };
        }


        /// <summary>
        ///     update group and his configuration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Response<String> UpdateGroups(GroupsVbm model)
        {
            String message = MsgUtils.OK;
            String stackTrace = String.Empty;


            try
            {

                using (TransactionScope scope = new TransactionScope())
                {

                    var group = _userGroupsDao.GetById(model.Id);

                    if (group == null)
                    {
                        return new Response<string>() { Message = MsgUtils.BAD_PARAMETERS, Success = false };
                    }

                    var config = _globalConfigsDao.GetById(group.GlobalConfigId);


                    if (config == null)
                    {
                        return new Response<string>() { Message = MsgUtils.BAD_PARAMETERS, Success = false };
                    }

                    config = model.ToEntity();
                    config.BaseUpdate("1", true);
                    _globalConfigsDao.Update(config);

                    group = model.ToEntity(config.Id);
                    group.BaseUpdate("1", true);
                    _userGroupsDao.Update(group);

                    scope.Complete();
                }
            }
            catch (Exception e)
            {
                message = e.StackTrace;
                if (e.InnerException != null)
                {
                    message = e.InnerException.Message;
                }

                stackTrace = e.StackTrace;

            }

            return new Response<String>() { Data = message, Total = 1, Success = message.Equals(MsgUtils.OK), Message = message, StackTrace = stackTrace };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsActive"></param>
        /// <returns></returns>
        public Response<List<UserGroupsVM>> GetAllGroups(bool IsActive = true)
        {
            String message = MsgUtils.OK;
            String stackTrace = String.Empty;
            Int32 total = 0;
            var respVm = new List<UserGroupsVM>();

            try
            {

                var resp = _userGroupsDao.GetAll(IsActive);
                if (resp == null)
                {
                    return new Response<List<UserGroupsVM>>()
                    {
                        Success = true,
                        Message = MsgUtils.NO_DATA
                    };
                }
                respVm = resp.ToVMs();
                total = respVm.Count;
            }
            catch (Exception e)
            {
                message = e.StackTrace;
                if (e.InnerException != null)
                {
                    message = e.InnerException.Message;
                }

                stackTrace = e.StackTrace;

            }

            return new Response<List<UserGroupsVM>>() { Data = respVm, Total = total, Success = message.Equals(MsgUtils.OK), Message = MsgUtils.OK, StackTrace = stackTrace };
        }



        public async Task<Response<Users>> RegisterUserAsync(RegisterVbm model)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                string userId = "1";



                if (model == null)
                {
                    throw new NullReferenceException("Register Model is null");
                }


                if (model.Password != model.ConfirmPassword)
                {
                    return new Response<Users>
                    {
                        Message = MsgUtils.PASSWD_DO_NOT_MATCH,
                        Success = false
                    };
                }

                var identityUser = new Users
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.UserName
                };

                identityUser.BaseCreate(userId, true);
                var result = await _userManager.CreateAsync(identityUser, model.Password);

                if (result.Succeeded)
                {
                    bool isRoleAdded = await AddUserRole(identityUser.Id, model.RoleName);
                    if (isRoleAdded)
                    {
                        scope.Complete();
                        return new Response<Users>
                        {
                            Message = MsgUtils.OK,
                            Success = true,
                            Data = identityUser
                        };

                    }
                }

                return new Response<Users>
                {
                    Message = MsgUtils.OPERATION_FAILED,
                    Success = false,
                    StackTrace = result.Errors.Select(e => e.Description).ToString()
                };
            }

        }

        public async Task<Response<Users>> UpdateUserAsync(string userId, RegisterVbm model)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                Users user = await _userManager.FindByIdAsync(userId);
                if (user == null || user.Id == null || user.Id == "")
                {
                    return new Response<Users>
                    {
                        Message = MsgUtils.INVALID_USER_ID,
                        Success = false
                    };
                }

                user.Name = model.Name;
                user.PhoneNumber = model.PhoneNumber;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.UserName = model.UserName;


                user.BaseUpdate("1", true);
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    bool isRoleAdded = await AddUserRole(user.Id, model.RoleName);
                    if (isRoleAdded)
                    {
                        scope.Complete();
                        // TODO: Send a confirmation email
                        return new Response<Users>
                        {
                            Message = MsgUtils.OK,
                            Success = true,
                            Data = user
                        };

                    }
                }

                return new Response<Users>
                {
                    Message = MsgUtils.OPERATION_FAILED,
                    Success = false,
                    StackTrace = result.Errors.Select(e => e.Description).ToString()
                };
            }
        }

        public async Task<UserManageResponse> LoginAsync(LoginVbm model)
        {
            String roleName = "";
            List<ClaimVM2> menuClaims = new List<ClaimVM2>();
            List<ClaimVM2> privClaims = new List<ClaimVM2>();

            List<String> allPrivClaims = _claimsDao.GetAll().Where(t => t.ClaimsType.Equals("priv")).Select(t => t.ClaimsValue).ToList();
            List<String> allMenuClaims = _claimsDao.GetAll().Where(t => t.ClaimsType.Equals("menu")).Select(t => t.ClaimsValue).ToList();
            List<ClaimVM2> claimVMs = new List<ClaimVM2>();
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user == null)
                {
                    return new UserManageResponse
                    {
                        Message = MsgUtils.INVALID_USER_EMAIL
                    };
                }
                var role = await _userManager.GetRolesAsync(user);
                if (role != null && role.Count > 0)
                {
                    roleName = role.First();
                }
                if (!user.IsActive)
                {
                    return new UserManageResponse
                    {
                        Message = MsgUtils.INVALID_USER
                    };
                }

                var result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!result)
                    return new UserManageResponse
                    {
                        Message = MsgUtils.INVALID_USER_PASSWD,
                        Success = false
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));
                IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);
                userClaims.Add(new Claim("X-USER", user.Id));
                List<String> userMenuClaims = userClaims.Where(t => t.Type.Equals("menu")).Select(t => t.Value).ToList();
                List<String> userPrivClaims = userClaims.Where(t => t.Type.Equals("priv")).Select(t => t.Value).ToList();

                #region Construction du Token
                var token = new JwtSecurityToken(
                    issuer: _configuration["AuthSettings:Issuer"],
                    audience: _configuration["AuthSettings:Audience"],
                    claims: userClaims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                    );

                string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
                #endregion


                #region format claims
                // Claims menu
                foreach (var claim in allMenuClaims)
                {
                    ClaimVM2 claimVM = new ClaimVM2();
                    claimVM.Value = claim;
                    claimVM.Status = userMenuClaims.Contains(claim);
                    menuClaims.Add(claimVM);
                }

                // Claims privillège
                foreach (var claim in allPrivClaims)
                {
                    ClaimVM2 claimVM = new ClaimVM2();
                    claimVM.Value = claim;
                    claimVM.Status = userPrivClaims.Contains(claim);
                    privClaims.Add(claimVM);
                }
                #endregion


                #region create session

                UserSession session = new UserSession
                {
                    ClientId = "WebApp",
                    UserId = user.Id,
                    UserName = user.Name,
                    Token = tokenAsString,
                    ExpireDate = DateTime.Now.AddMinutes(30),
                    IssuedDate = DateTime.Now,
                };
                session.BaseCreate(user.Id, true);
                _userSessionDao.Insert(session);

                #endregion

                return new UserManageResponse
                {
                    MenuClaims = menuClaims,
                    PrivClaims = privClaims,
                    User = user,
                    Role = roleName,
                    Name = user.LastName,
                    Token = tokenAsString,
                    Message = MsgUtils.OK,
                    Success = true,
                    ExpiredDate = token.ValidTo
                };
            }
            catch (Exception e)
            {
                String stacktrace = "";

                if (e.InnerException != null)
                {
                    stacktrace = e.InnerException.Message;
                }
                else
                {
                    stacktrace = e.StackTrace;
                }
                return new UserManageResponse
                {
                    Token = "",
                    Message = MsgUtils.OPERATION_FAILED,
                    Success = false,
                    StackTrace = stacktrace
                };

            }
        }


        public async Task<Response<IdentityRole>> CreateRole(string roleName, List<UserClaim> claims)
        {
            IdentityRole role = new IdentityRole(roleName);
            IdentityResult result;
            try
            {
                //Non terminé
                result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    if (role != null && role.Id != null)
                    {

                        foreach (UserClaim claim in claims)
                        {
                            await _roleManager.AddClaimAsync(role, new Claim(claim.Type, claim.Value));
                        }
                    }
                    return new Response<IdentityRole>
                    {
                        Success = true,
                        Data = role,
                        Message = MsgUtils.OK
                    };
                }
                return new Response<IdentityRole>
                {
                    Message = MsgUtils.OPERATION_FAILED,
                    Success = false,
                    StackTrace = result.Errors.Select(e => e.Description).ToString()
                };

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Print(e.StackTrace);
                throw;
                string message = MsgUtils.OPERATION_FAILED;
                if (e.InnerException != null)
                {
                    message = e.InnerException.Message;
                }
            }
        }


        public async Task<Response<IdentityRole>> UpdateRole(string roleId, string roleName, List<UserClaim> claims)
        {
            IdentityRole role = null;
            IList<Claim> oldClaims;
            IdentityResult result;
            try
            {
                role = await _roleManager.FindByIdAsync(roleId);
                role.Name = roleName;
                result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    if (role != null && role.Id != null)
                    {
                        oldClaims = await _roleManager.GetClaimsAsync(role);
                        IList<Users> users = await _userManager.GetUsersInRoleAsync(roleName);

                        //remove old claims from role and user of that role
                        foreach (Claim claim in oldClaims)
                        {
                            await _roleManager.RemoveClaimAsync(role, claim);
                            foreach (Users user in users)
                            {
                                await _userManager.RemoveClaimAsync(user, claim);
                            }
                        }

                        foreach (UserClaim claim in claims)
                        {
                            await _roleManager.AddClaimAsync(role, new Claim(claim.Type, claim.Value));

                            foreach (Users user in users)
                            {
                                await _userManager.AddClaimAsync(user, new Claim(claim.Type, claim.Value));
                            }
                        }
                    }
                    return new Response<IdentityRole>
                    {
                        Success = true,
                        Data = role,
                        Message = MsgUtils.OK
                    };
                }

                return new Response<IdentityRole>
                {
                    Message = MsgUtils.OPERATION_FAILED,
                    Success = false,
                    StackTrace = result.Errors.Select(e => e.Description).ToString()
                };

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Print(e.StackTrace);
                throw;
                string message = MsgUtils.OPERATION_FAILED;
                string stacktrace = e.StackTrace;

                if (e.InnerException != null)
                {
                    message = e.InnerException.Message;
                }
            }
        }

        public async Task<Response<int>> ManageRoleClaims(String roleName, List<UserClaim> claims)
        {
            IList<Claim> oldClaims;
            IdentityResult result = new IdentityResult();
            try
            {
                IdentityRole role = await _roleManager.FindByNameAsync(roleName);

                if (role != null)
                {
                    oldClaims = await _roleManager.GetClaimsAsync(role);
                    IList<Users> users = await _userManager.GetUsersInRoleAsync(roleName);

                    //remove old claims from role and user of that role
                    foreach (Claim claim in oldClaims)
                    {
                        await _roleManager.RemoveClaimAsync(role, claim);
                        foreach (Users user in users)
                        {
                            await _userManager.RemoveClaimAsync(user, claim);

                        }
                    }

                    foreach (UserClaim claim in claims)
                    {
                        await _roleManager.AddClaimAsync(role, new Claim(claim.Type, claim.Value));

                        foreach (Users user in users)
                        {
                            await _userManager.AddClaimAsync(user, new Claim(claim.Type, claim.Value));

                        }
                    }

                }
            }
            catch (Exception e)
            {
                return new Response<int>
                {
                    Data = 1,
                    Message = MsgUtils.OPERATION_FAILED,
                    Success = false,
                    StackTrace = e.StackTrace
                };
            }
            return new Response<int>
            {
                Data = 1,
                Message = MsgUtils.OK,
                Success = true
            };
        }

        public async Task<bool> AddUserRole(string userId, string roleName)
        {
            Users user;
            IdentityRole role;
            IList<Claim> claims;
            try
            {
                user = await _userManager.FindByIdAsync(userId);
                role = await _roleManager.FindByNameAsync(roleName);



                //S'assure que le role et l'utilisateur existe et que ce dernier n'est pas encore dans ce rôle
                if (user != null && role != null && !await _userManager.IsInRoleAsync(user, roleName))
                {
                    //récupération des role de l'utilisateur
                    var userRoles = await _userManager.GetRolesAsync(user);
                    if (userRoles != null && userRoles.Count > 0)
                    {
                        //retirer l'utilisateur du role précédent
                        foreach (string userRole in userRoles)
                        {
                            await _userManager.RemoveFromRoleAsync(user, userRole);
                        }

                        //lui enlever les claims précédents
                        var userClaims = await _userManager.GetClaimsAsync(user);
                        if (userClaims != null && userClaims.Count > 0)
                        {
                            foreach (Claim claim in userClaims)
                            {
                                await _userManager.RemoveClaimAsync(user, claim);

                            }
                        }
                    }

                    // l'ajouter dans le nouveau role
                    await _userManager.AddToRoleAsync(user, roleName);
                    claims = await _roleManager.GetClaimsAsync(role);

                    //lui ajouter les claims du role actuel
                    if (claims != null && claims.Count > 0)
                    {
                        foreach (Claim claim in claims)
                        {
                            await _userManager.AddClaimAsync(user, claim);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<Response<List<RoleVM>>> GetAllRoles()
        {
            var response = new Response<List<RoleVM>> { Message = MsgUtils.OK, Success = true };
            List<RoleVM> roleVMs = new List<RoleVM>();
            IList<IdentityRole> identityRoles = new List<IdentityRole>();
            try
            {
                var roles = _roleManager.Roles.ToList();
                foreach (var role in roles)
                {
                    RoleVM roleVM = new RoleVM();
                    roleVM.Claims = new List<UserClaim>();
                    var claims = await _roleManager.GetClaimsAsync(role);
                    roleVM.Id = role.Id;
                    roleVM.Name = role.Name;
                    foreach (var claim in claims)
                    {
                        roleVM.Claims.Add(new UserClaim { Type = claim.Type, Value = claim.Value });
                    }
                    roleVMs.Add(roleVM);
                }
                response.Data = roleVMs;
            }
            catch (Exception e)
            {
                response.Message = MsgUtils.OPERATION_FAILED;
                response.StackTrace = e.StackTrace;
                return response;
            }
            return response;
        }

        public async Task<Response<List<UserVM>>> GetAllUsers()
        {
            var response = new Response<List<UserVM>> { Message = MsgUtils.OK, Success = true };
            List<Users> users = new List<Users>();
            List<UserVM> userVMs = new List<UserVM>();
            IList<IdentityRole> identityRoles = new List<IdentityRole>();
            try
            {
                users = _userManager.Users.Where(t => t.IsActive).ToList();
                foreach (var user in users)
                {
                    UserVM userVM = user.ToModel();
                    IList<String> roles = await _userManager.GetRolesAsync(user);
                    if (roles != null && roles.Count > 0 && roles.First() != null)
                    {
                        var role = await _roleManager.FindByNameAsync(roles.First());
                        if (role != null)
                        {
                            userVM.RoleId = role.Id;
                            userVM.RoleName = role.Name;
                        }
                    }
                    userVMs.Add(userVM);
                }
            }
            catch (Exception e)
            {
                response.Message = MsgUtils.OPERATION_FAILED;
                response.StackTrace = e.StackTrace;
                return response;
            }
            response.Data = userVMs;
            response.Total = userVMs.Count;
            return response;
        }

        public async Task<Response<UserVM>> GetUserDetails(string userId)
        {
            var response = new Response<UserVM> { Message = MsgUtils.OK, Success = true };
            Users user = new Users();
            IList<IdentityRole> identityRoles = new List<IdentityRole>();
            try
            {
                user = await _userManager.FindByIdAsync(userId);

                UserVM userVM = user.ToModel();
                IList<String> roles = await _userManager.GetRolesAsync(user);
                if (roles != null && roles.Count > 0 && roles.First() != null)
                {
                    var role = await _roleManager.FindByNameAsync(roles.First());
                    if (role != null)
                    {
                        userVM.RoleId = role.Id;
                        userVM.RoleName = role.Name;
                    }
                }
                response.Data = userVM;
            }
            catch (Exception e)
            {
                response.Message = MsgUtils.OPERATION_FAILED;
                response.StackTrace = e.StackTrace;
                return response;
            }

            return response;
        }

        public Response<List<ClaimsPrivilleges>> GetAllClaimsPrivilleges()
        {
            string Msg = MsgUtils.OK;
            String stackTrace = String.Empty;
            List<Claims> claims = new List<Claims>();
            List<ClaimsPrivilleges> claimsPrivs = new List<ClaimsPrivilleges>();
            Claims priv = new Claims();


            var total = 0;

            try
            {
                claims = _claimsDao.GetAll().Where(t => t.ClaimsType.Equals("priv") && t.IsActive).ToList();
                total = claims.Count();
                var result = claims.GroupBy(c => c.Code, c => c.ClaimsValue, (key, value) => new
                {
                    Code = key,
                    Privilleges = value
                }).Where(t => t.Code != null);

                foreach (var item in result)
                {
                    ClaimsPrivilleges claimsPriv = new ClaimsPrivilleges();
                    claimsPriv.Code = item.Code;
                    claimsPriv.Privilleges = item.Privilleges;
                    claimsPrivs.Add(claimsPriv);
                }

                total = result.Count();
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine(e.InnerException.StackTrace);
                    stackTrace = e.InnerException.StackTrace;
                    Msg = e.InnerException.Message;
                }
            }


            var response = new Response<List<ClaimsPrivilleges>>

            {
                Message = Msg,
                Success = true,
                Total = total,
                Data = claimsPrivs
            };

            return response;
        }

        public Response<List<ClaimsPrivilleges>> GetAllMenuClaimsPrivilleges()
        {
            string Msg = MsgUtils.OK;
            String stackTrace = String.Empty;
            List<Claims> claims = new List<Claims>();
            List<ClaimsPrivilleges> claimsPrivs = new List<ClaimsPrivilleges>();
            Claims priv = new Claims();


            var total = 0;

            try
            {
                claims = (List<Claims>)_claimsDao.GetClaimsMenuParentPriv();

                var result = claims.GroupBy(c => c.Description, c => c.ClaimsValue, (key, value) => new
                {
                    Code = key,
                    Privilleges = value
                });

                total = result.Count();
                foreach (var item in result)
                {
                    ClaimsPrivilleges claimsPriv = new ClaimsPrivilleges();
                    claimsPriv.Code = item.Code;
                    claimsPriv.Privilleges = item.Privilleges;
                    claimsPrivs.Add(claimsPriv);
                }

                total = result.Count();
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine(e.InnerException.StackTrace);
                    stackTrace = e.InnerException.StackTrace;
                    Msg = e.InnerException.Message;
                }
            }

            var response = new Response<List<ClaimsPrivilleges>>
            {
                Message = Msg,
                Success = true,
                Total = total,
                Data = claimsPrivs
            };

            return response;
        }

        public async Task<Response<Users>> UpdateUserAsync(RegisterVbm model, String userId)
        {
            IdentityResult result = new IdentityResult();
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {


                if (model == null)
                {
                    throw new NullReferenceException("Register Model is null");
                }


                var user = await _userManager.FindByIdAsync(userId);
                user.Name = model.Name;
                user.PhoneNumber = model.PhoneNumber;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.UserName = model.UserName;


                result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    bool isRoleAdded = await AddUserRole(userId, model.RoleName);
                    if (isRoleAdded)
                    {
                        scope.Complete();
                        // TODO: Send a confirmation email
                        return new Response<Users>
                        {
                            Message = MsgUtils.OK,
                            Success = true,
                            Data = user
                        };
                    }
                }
            }



            return new Response<Users>
            {
                Message = MsgUtils.OPERATION_FAILED,
                Success = false,
                StackTrace = result.Errors.Select(e => e.Description).ToString()
            };
        }

        public async Task<Response<RoleVM>> GetRoleById(string roleId)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(roleId);
                RoleVM roleVM = new RoleVM();
                roleVM.Claims = new List<UserClaim>();
                var claims = await _roleManager.GetClaimsAsync(role);
                roleVM.Id = role.Id;
                roleVM.Name = role.Name;
                foreach (var claim in claims)
                {
                    roleVM.Claims.Add(new UserClaim { Type = claim.Type, Value = claim.Value });
                }

                return new Response<RoleVM>
                {
                    Success = true,
                    Data = roleVM,
                    Message = MsgUtils.OK,
                };
            }
            catch (Exception e)
            {
                return new Response<RoleVM>
                {
                    Success = false,
                    StackTrace = e.StackTrace,
                    Message = MsgUtils.OPERATION_FAILED,
                };
            }

        }

        public async Task<Response<int>> DeleteRole(string roleId)
        {
            try
            {

                var role = await _roleManager.FindByIdAsync(roleId);
                if (role != null && role.Id != null && role.Id != "")
                {
                    IList<Users> users = await _userManager.GetUsersInRoleAsync(role.Name);
                    users = users.Where(t => t.IsActive).ToList();

                    if (users != null && users.Count > 0)
                    {
                        return new Response<int>
                        {
                            Success = false,
                            Message = MsgUtils.FIRST_REMOVE_USER_FROM_ROLE,
                        };
                    }

                    await _roleManager.DeleteAsync(role);


                    return new Response<int>
                    {
                        Success = true,
                        Data = 1,
                        Message = MsgUtils.OK,
                    };
                }
                return new Response<int>
                {
                    Success = false,
                    Message = MsgUtils.INVALID_ROLE_ID,
                };
            }
            catch (Exception e)
            {
                return new Response<int>
                {
                    Success = false,
                    Data = 0,
                    StackTrace = e.StackTrace,
                    Message = MsgUtils.OPERATION_FAILED,
                };
            }
        }

        public async Task<Response<int>> DeleteUser(string userId)
        {
            try
            {

                var user = await _userManager.FindByIdAsync(userId);
                user.BaseUpdate("1", false);
                await _userManager.UpdateAsync(user);

                return new Response<int>
                {
                    Success = true,
                    Data = 1,
                    Message = MsgUtils.OK,
                };
            }
            catch (Exception e)
            {
                return new Response<int>
                {
                    Success = false,
                    Data = 0,
                    StackTrace = e.StackTrace,
                    Message = MsgUtils.OPERATION_FAILED,
                };
            }
        }

        public async Task<Response<List<UserVM>>> GetUsersByFilter(UserFilter model, int page, int pageSize, bool hasPagination)

        {
            var response = new Response<List<UserVM>> { Message = MsgUtils.OK, Success = true };
            List<Users> users = new List<Users>();
            List<UserVM> userVMs = new List<UserVM>();
            IList<IdentityRole> identityRoles = new List<IdentityRole>();
            try
            {
                users = _userManager.Users.ToList();
                if (model.Status == 1)
                {
                    users = users.Where(t => !t.IsActive).ToList();
                }
                else if (model.Status == 2)
                {
                    users = users.Where(t => t.IsActive).ToList();
                }

                if (model.Email != null && model.Email != "")
                {
                    users = users.Where(t => t.Email.ToLower().Contains(model.Email.ToLower())).ToList();
                }
                if (model.Name != null && model.Name != "")
                {
                    users = users.Where(t => t.Name.ToLower().Contains(model.Name.ToLower())).ToList();
                }
                if (model.UserName != null && model.UserName != "")
                {
                    users = users.Where(t => t.UserName.ToLower().Contains(model.UserName.ToLower())).ToList();
                }
                if (model.LastName != null && model.LastName != "")
                {
                    users = users.Where(t => t.LastName.ToLower().Contains(model.LastName.ToLower())).ToList();
                }
                if (model.PhoneNumber != null && model.PhoneNumber != "")
                {
                    users = users.Where(t => t.PhoneNumber.Contains(model.PhoneNumber)).ToList();
                }


                if (hasPagination)
                {
                    users = users.Skip(page * pageSize).Take(pageSize).OrderBy(t => t.Name).ToList();
                }

                foreach (var user in users)
                {
                    UserVM userVM = user.ToModel();
                    IList<String> roles = await _userManager.GetRolesAsync(user);
                    if (roles != null && roles.Count > 0 && roles.First() != null)
                    {
                        var role = await _roleManager.FindByNameAsync(roles.First());
                        if (role != null)
                        {
                            userVM.RoleId = role.Id;
                            userVM.RoleName = role.Name;
                        }
                    }
                    userVMs.Add(userVM);
                }
            }
            catch (Exception e)
            {
                response.Message = MsgUtils.OPERATION_FAILED;
                response.StackTrace = e.StackTrace;
                response.Success = false;
                return response;
            }
            response.Data = userVMs;
            response.Total = userVMs.Count;
            return response;
        }


        public async Task<Response<IdentityResult>> ChangeUserPasswdAsync(ChangePswdVbm model, string userId)
        {
            try
            {

                var user = await _userManager.FindByIdAsync(userId);
                user.BaseUpdate("1", true);
                IdentityResult result = await _userManager.ChangePasswordAsync(user, model.CurrentPasswd, model.NewPasswd);


                return new Response<IdentityResult>
                {
                    Success = true,
                    Data = result,
                    Message = MsgUtils.OK,
                };
            }
            catch (Exception e)
            {
                return new Response<IdentityResult>
                {
                    Success = false,
                    StackTrace = e.StackTrace,
                    Message = MsgUtils.OPERATION_FAILED,
                };

            }
        }

        public async Task<Response<UserVM>> GetCurrentUser()
        {
            UserVM userVM = new UserVM();
            try
            {
                string userId = "1";
                var user = await _userManager.FindByIdAsync(userId);

                userVM = user.ToModel();
                IList<String> roles = await _userManager.GetRolesAsync(user);
                if (roles != null && roles.Count > 0 && roles.First() != null)
                {
                    var role = await _roleManager.FindByNameAsync(roles.First());
                    if (role != null)
                    {
                        userVM.RoleId = role.Id;
                        userVM.RoleName = role.Name;
                    }
                }


                return new Response<UserVM>
                {
                    Total = 1,
                    Success = true,
                    Data = userVM,
                    Message = MsgUtils.OK,
                };
            }
            catch (Exception e)
            {
                return new Response<UserVM>
                {
                    Success = false,
                    StackTrace = e.StackTrace,
                    Message = MsgUtils.OPERATION_FAILED,
                };
            }
        }





    }
}
