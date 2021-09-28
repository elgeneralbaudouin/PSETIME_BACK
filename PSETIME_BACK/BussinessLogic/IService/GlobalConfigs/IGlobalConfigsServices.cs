using PSETIME_BACK.DAL.Models.Entities.GlobalConfigs;
using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.GlobalConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.BussinessLogic.IService.GlobalConfigs
{
    public interface IGlobalConfigsServices
    {
        Response<List<GlobalConfigsVM>> GetAll(bool IsActive = true);
    }
}
