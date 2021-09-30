using Microsoft.Extensions.DependencyInjection;
using PSETIME_BACK.BussinessLogic.ImplService.GlobalConfigs;
using PSETIME_BACK.BussinessLogic.ImplService.Imports;
using PSETIME_BACK.BussinessLogic.ImplService.RevendPerms.Permissions;
using PSETIME_BACK.BussinessLogic.ImplService.RevendPerms.Revendications;
using PSETIME_BACK.BussinessLogic.IService.GlobalConfigs;
using PSETIME_BACK.BussinessLogic.IService.Imports;
using PSETIME_BACK.BussinessLogic.IService.RevendPerms.Permissions;
using PSETIME_BACK.BussinessLogic.IService.RevendPerms.Revendications;
using PSETIME_BACK.BussinessLogic.ImplService.UserManager;
using PSETIME_BACK.BussinessLogic.IService.GlobalConfigs;
using PSETIME_BACK.BussinessLogic.IService.Imports;
using PSETIME_BACK.BussinessLogic.IService.UserManager;
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


            #region permission and revendication 

            services.AddScoped<IPermissionUserServices, PermissionUserServices>();

            services.AddScoped<IRevendicationUsersServices, RevendicationUsersServices>();
            

            #endregion
            #region UserManager
            services.AddScoped<IUsersServices, UsersServices>();
            #endregion
            return services;
        }
    }
}