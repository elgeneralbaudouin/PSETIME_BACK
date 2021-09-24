using PSETIME_BACK.BussinessLogic.IService.GlobalConfigs;
using PSETIME_BACK.DAL.DAOs.IDAO.GlobalConfigs;
using PSETIME_BACK.DAL.Models.Entities.GlobalConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.BussinessLogic.ImplService.GlobalConfigs
{
    /// <summary>
    ///     Services of globalconfiguration
    /// </summary>
    public class GlobalConfigsServices : IGlobalConfigsServices
    {
        // DI
        private readonly IGlobalConfigsDao _globalConfigsDao;

        public GlobalConfigsServices(IGlobalConfigsDao globalConfigsDao)
        {
            _globalConfigsDao = globalConfigsDao;
        }

        public List<GlobalConfig> GetAll (bool IsActive = true) 
        {
            var response = _globalConfigsDao.GetAll(IsActive);
            return response;
        }
    }
}
