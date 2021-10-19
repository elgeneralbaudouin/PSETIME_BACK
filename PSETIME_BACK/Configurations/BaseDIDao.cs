using Microsoft.Extensions.DependencyInjection;
using PSETIME_BACK.BussinessLogic.ImplService.UserManager;
using PSETIME_BACK.DAL.DAOs.IDAO.GlobalConfigs;
using PSETIME_BACK.DAL.DAOs.IDAO.Imports;
using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms;
using PSETIME_BACK.DAL.DAOs.IDAO.UserManager;
using PSETIME_BACK.DAL.DAOs.ImplDAO.GlobalConfigs;
using PSETIME_BACK.DAL.DAOs.ImplDAO.Imports.NewFolder;
using PSETIME_BACK.DAL.DAOs.ImplDAO.RevendPerms;
using PSETIME_BACK.DAL.DAOs.ImplDAO.UserManager;

namespace PSETIME_BACK.Configurations
{

    /// <summary>
    ///     injection des dependances de tous les DAO
    /// </summary>
    public static class BaseDIDao
    {

        public static IServiceCollection AddBaseDAO(this IServiceCollection services)
        {
            #region GlobalConfig
            services.AddScoped<IGlobalConfigsDao, GlobalConfigsDao>();
            #endregion

            #region Importation
            services.AddScoped<IUserTimeDao, UserTimeDao>();
            #endregion

            #region permission and revendication 

            services.AddScoped<IPermissionUserDao, PermissionUserDao>();
            services.AddScoped<IPermissionsStatusDao, PermissionsStatusDao>();
            services.AddScoped<IRevendicationUserDao, RevendicationUserDao>();
            services.AddScoped<IRevendicationStatusDao, RevendicationStatusDao>();
            #endregion

            #region UserManager
            services.AddScoped<IUserGroupsDao, UserGroupsDao>();
            services.AddScoped<IClaimsDao, ClaimsDao>();
            services.AddScoped<IUserSessionDao, UserSessionDao>();

            #endregion

            #region RevendPerms

            #endregion

            return services;
        }

    }
}
