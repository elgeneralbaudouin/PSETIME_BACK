using PSETIME_BACK.DTO.VBM.RevendPerms;
using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.RevendPerms.Revendications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.BussinessLogic.IService.RevendPerms.Revendications
{
    public interface IRevendicationUserServices
    {

        public Response<String> CreateRevendication(RevendicationVbm model);
        Response<List<RevendicationVbm>> GetAllstatus(bool IsActive = true);
    }
}
