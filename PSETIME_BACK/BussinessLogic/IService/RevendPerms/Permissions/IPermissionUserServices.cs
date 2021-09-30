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
        Response<List<PermissionUserVM>> GetAll(bool IsActive = true);
    }
}
