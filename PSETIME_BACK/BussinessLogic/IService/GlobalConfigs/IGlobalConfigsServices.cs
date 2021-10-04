using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.GlobalConfigs;
using System.Collections.Generic;

namespace PSETIME_BACK.BussinessLogic.IService.GlobalConfigs
{
    public interface IGlobalConfigsServices
    {
        Response<List<GlobalConfigsVM>> GetAll(bool IsActive = true);
    }
}
