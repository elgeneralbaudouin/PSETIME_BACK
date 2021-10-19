using Microsoft.AspNetCore.Mvc;
using PSETIME_BACK.BussinessLogic.IService.UserManager;
using PSETIME_BACK.DTO.VBM.UserManager;
using PSETIME_BACK.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSETIME_BACK.Controllers.UserManager
{
    /// <summary>
    ///     prefix des routes de gestion de l'utilisateur par "api/u"
    ///     en lieu et place de "api/Users"
    /// </summary>
    [Route("api/u")]
    [ApiController]
    public class UsersController : Controller
    {
        readonly IUsersServices _usersServices;
        public UsersController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        [HttpPost("create/group")]
        public ActionResult CreateGroup(GroupsVbm model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var result = _usersServices.CreateGroups(model);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }

        [HttpPut("update/group")]
        public ActionResult UpdateGroup(GroupsVbm model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var result = _usersServices.UpdateGroups(model);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAllConfigs(bool IsActive = true)
        {
            var result = _usersServices.GetAllGroups(IsActive);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }


        #region Administration 

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterVbm model)
        {
            if (ModelState.IsValid)
            {
                var result = await _usersServices.RegisterUserAsync(model);

                if (result.Success)
                    return Ok(result); // Status Code: 200

                return BadRequest(result);
            }
            return BadRequest("some properties are not valid"); // Status code : 400
        }

        [HttpPost("updateuser/{userId}")]
        public async Task<ActionResult> RegisterAsync(RegisterVbm model, string userId)
        {
            if (ModelState.IsValid)
            {
                var result = await _usersServices.UpdateUserAsync(model, userId);

                if (result.Success)
                    return Ok(result); // Status Code: 200

                return BadRequest(result);
            }
            return BadRequest("some properties are not valid"); // Status code : 400
        }


        [HttpPut("users/{userId}")]
        public async Task<ActionResult> UpdateUserAsync(RegisterVbm model, string userId)
        {
            if (ModelState.IsValid)
            {
                var result = await _usersServices.UpdateUserAsync(model, userId);

                if (result.Success)
                    return Ok(result); // Status Code: 200

                return BadRequest(result);
            }
            return BadRequest("some properties are not valid"); // Status code : 400
        }

        [HttpPatch("users/changepasswd/{userId}")]
        public async Task<ActionResult> ChangeUserAsync(ChangePswdVbm model, string userId)
        {
            var result = await _usersServices.ChangeUserPasswdAsync(model, userId);


            return Ok(result);

        }


        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginVbm model)
        {
            if (ModelState.IsValid)
            {
                var result = await _usersServices.LoginAsync(model);
                if (result.Success)
                    return Ok(result);
                return BadRequest(result);
            }
            return BadRequest("some properties are not valid");
        }

        [HttpGet("administration/claims/priv")]
        public ActionResult GetClaims()
        {
            var result = _usersServices.GetAllClaimsPrivilleges();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("administration/claims/menu")]
        public ActionResult GetAllMenuClaimsPrivilleges()
        {
            var result = _usersServices.GetAllMenuClaimsPrivilleges();
            if (result.Success)

            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("createrole")]
        public async Task<ActionResult> CreateRole([FromBody] List<UserClaim> claims, string roleName)
        {
            if (roleName != null || roleName != "")
            {
                var result = await _usersServices.CreateRole(roleName, claims);
                return Ok(result);
            }
            return BadRequest(MsgUtils.INVALID_ROLE_NAME);
        }

        [HttpPut("updaterole/{roleId}")]
        public async Task<ActionResult> UpdateRole([FromBody] List<UserClaim> claims, string roleName, string roleId)
        {
            if (roleName != null || roleName != "")
            {
                var result = await _usersServices.UpdateRole(roleId, roleName, claims);
                return Ok(result);
            }
            return BadRequest(MsgUtils.INVALID_ROLE_NAME);
        }

        //[Authorize(Policy = "UpdateRole")]
        [HttpPut("managerole/{roleName}")]
        public async Task<ActionResult> ManageRole([FromBody] List<UserClaim> claims, string roleName)
        {
            if (claims != null && roleName != null && roleName != "")
            {
                var result = await _usersServices.ManageRoleClaims(roleName, claims);
                return Ok(result);
            }
            return BadRequest("invalid claims");
        }

        [HttpGet("role/{roleId}")]
        public async Task<ActionResult> GetRoleById(string roleId)
        {
            if (roleId != null || roleId != "")
            {
                var result = await _usersServices.GetRoleById(roleId);
                return Ok(result);
            }
            return BadRequest(MsgUtils.INVALID_ROLE_ID);
        }

        [HttpDelete("role/{roleId}")]
        public async Task<ActionResult> DeleteRoleById(string roleId)
        {
            if (roleId != null || roleId != "")
            {
                var result = await _usersServices.DeleteRole(roleId);
                return Ok(result);
            }
            return BadRequest(MsgUtils.INVALID_ROLE_ID);
        }

        [HttpDelete("user/{userId}")]
        public async Task<ActionResult> DeleteUserById(string userId)
        {
            if (userId != null || userId != "")
            {
                var result = await _usersServices.DeleteUser(userId);
                return Ok(result);
            }
            return BadRequest(MsgUtils.INVALID_USER_ID);
        }


        [HttpPost("users/filter")]
        public async Task<ActionResult> GetUsersFilter(UserFilter model, int page = 1, int pageSize = 10, bool hasPagination = true)
        {
            var result = await _usersServices.GetUsersByFilter(model, page - 1, pageSize, hasPagination);
            return Ok(result);
        }

        [HttpGet("users")]
        public async Task<ActionResult> GetUsers()
        {
            var result = await _usersServices.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("current")]
        public async Task<ActionResult> GetCurrentUser()
        {
            var result = await _usersServices.GetCurrentUser();
            return Ok(result);
        }

        [HttpGet("roles")]
        public async Task<ActionResult> GetRoles()
        {
            var result = await _usersServices.GetAllRoles();
            return Ok(result);
        }

        [HttpGet("users/{userId}")]
        public async Task<ActionResult> GetUserDetails(string userId)
        {
            var result = await _usersServices.GetUserDetails(userId);
            return Ok(result);
        }

        [HttpPut("roles")]
        public ActionResult GetAllRole()
        {
            var result = _usersServices.GetAllRoles();
            return Ok(result);
        }
        #endregion
    }
}
