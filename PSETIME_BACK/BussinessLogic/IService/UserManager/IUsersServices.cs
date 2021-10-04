using PSETIME_BACK.DTO.VBM.UserManager;
using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.UserManager;
using System;
using System.Collections.Generic;

namespace PSETIME_BACK.BussinessLogic.IService.UserManager
{
    public interface IUsersServices
    {
        public Response<String> CreateGroups(GroupsVbm model);
        public Response<List<UserGroupsVM>> GetAllGroups(bool IsActive = true);
    }
}
