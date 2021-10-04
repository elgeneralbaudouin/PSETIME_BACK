using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.RevendPerms.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.BussinessLogic.IService.RevendPerms.Permissions
{
    public interface IPermissionsStatusServices
    {
        Response<List<PermissionsStatusVM>> GetAll(bool IsActive = true);
    }
}
