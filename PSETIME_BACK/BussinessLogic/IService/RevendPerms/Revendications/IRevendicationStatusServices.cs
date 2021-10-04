using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.RevendPerms.Revendications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.BussinessLogic.IService.RevendPerms.Revendications
{
    public interface IRevendicationStatusServices
    {
        Response<List<RevendicationStatusVM>> GetAll(bool IsActive = true);
    }
}
