using Microsoft.AspNetCore.Identity;
using PSETIME_BACK.DAL.Models.Entities.UserManager;
using PSETIME_BACK.DTO.VBM.UserManager;
using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.UserManager;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSETIME_BACK.BussinessLogic.IService.UserManager
{
    public interface IUsersServices
    {
        public Response<String> CreateGroups(GroupsVbm model);
        public Response<String> UpdateGroups(GroupsVbm model);
        public Response<List<UserGroupsVM>> GetAllGroups(bool IsActive = true);


        public Task<Response<IdentityRole>> CreateRole(string roleName, List<UserClaim> claims);
        public Task<Response<IdentityRole>> UpdateRole(string roleId, string roleName, List<UserClaim> claims);
        public Task<Response<List<UserVM>>> GetAllUsers();
        public Task<Response<UserVM>> GetUserDetails(String userId);
        public Task<bool> AddUserRole(String userId, String roleName);

        public Task<Response<int>> ManageRoleClaims(String roleName, List<UserClaim> claims);
        public Task<Response<Users>> RegisterUserAsync(RegisterVbm model);
        public Task<Response<Users>> UpdateUserAsync(RegisterVbm model, String userId);

        public Task<UserManageResponse> LoginAsync(LoginVbm model);

        public Task<Response<UserVM>> GetCurrentUser();

        public Task<Response<List<RoleVM>>> GetAllRoles();
        public Response<List<ClaimsPrivilleges>> GetAllClaimsPrivilleges();
        public Response<List<ClaimsPrivilleges>> GetAllMenuClaimsPrivilleges();
        public Task<Response<RoleVM>> GetRoleById(string roleId);
        public Task<Response<int>> DeleteRole(string roleId);
        public Task<Response<int>> DeleteUser(string userId);
        public Task<Response<List<UserVM>>> GetUsersByFilter(UserFilter model, int page, int pageSize, bool hasPagination);
        public Task<Response<IdentityResult>> ChangeUserPasswdAsync(ChangePswdVbm model, string userId);
    }
}
