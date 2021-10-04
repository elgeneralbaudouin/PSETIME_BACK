using PSETIME_BACK.DTO.VBM.RevendPerms;
using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.RevendPerms;
using System;
using System.Collections.Generic;

namespace PSETIME_BACK.BussinessLogic.IService.RevendPerms
{
    public interface IRevendPermsServices
    {
        #region Permissions
        public Response<List<PermissionsStatusVM>> GetAllPermissionStatus(bool IsActive = true);
        public Response<String> CreatePermission(PermissionVbm model);
        public Response<List<PermissionUserVM>> GetAllPermission(bool IsActive = true);

        #endregion

        #region Revendications
        public Response<List<RevendicationStatusVM>> GetAllRevendicationStatus(bool IsActive = true);
        public Response<String> CreateRevendication(RevendicationVbm model);
        public Response<List<RevendicationUserVM>> GetAllRevendication(bool IsActive = true);
        #endregion

    }
}
