using Microsoft.Extensions.DependencyInjection;
using PSETIME_BACK.BussinessLogic.ImplService.GlobalConfigs;
using PSETIME_BACK.BussinessLogic.ImplService.Imports;
using PSETIME_BACK.BussinessLogic.ImplService.RevendPerms;
using PSETIME_BACK.BussinessLogic.ImplService.UserManager;
using PSETIME_BACK.BussinessLogic.IService.GlobalConfigs;
using PSETIME_BACK.BussinessLogic.IService.Imports;
using PSETIME_BACK.BussinessLogic.IService.RevendPerms;
using PSETIME_BACK.BussinessLogic.IService.UserManager;

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

            services.AddScoped<IRevendPermsServices, RevendPermsServices>();


            #endregion
            #region UserManager
            services.AddScoped<IUsersServices, UsersServices>();
            #endregion
            return services;
        }
    }
}