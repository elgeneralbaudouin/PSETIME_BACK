using PSETIME_BACK.DAL.Models.Entities.GlobalConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.BussinessLogic.IService.GlobalConfigs
{
    public interface IGlobalConfigsServices
    {
        List<GlobalConfig> GetAll(bool IsActive = true);
    }
}
