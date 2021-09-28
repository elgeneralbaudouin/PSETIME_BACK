using Microsoft.Extensions.DependencyInjection;
using PSETIME_BACK.BussinessLogic.ImplService.GlobalConfigs;
using PSETIME_BACK.BussinessLogic.ImplService.Imports;
using PSETIME_BACK.BussinessLogic.IService.GlobalConfigs;
using PSETIME_BACK.BussinessLogic.IService.Imports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.Configurations
{
    public static class BaseDIServices
    {
        public static IServiceCollection AddBaseServices(this IServiceCollection services)
        {
            #region GlobalConfig
            services.AddScoped<IGlobalConfigsServices, GlobalConfigsServices>();
            #endregion

            #region Importation
            services.AddScoped<IImportServices, ImportServices>();
            #endregion
            return services;
        }
    }
}
