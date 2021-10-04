using PSETIME_BACK.DTO.VBM.RevendPerms;
using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.RevendPerms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.BussinessLogic.IService.RevendPerms.Permissions
{
    public interface IPermissionUserServices
    {
        public Response<String> CreatePermission(PermissionVbm model);
        Response<List<PermissionUserVM>> GetAllstatus(bool IsActive = true);
    }
}
