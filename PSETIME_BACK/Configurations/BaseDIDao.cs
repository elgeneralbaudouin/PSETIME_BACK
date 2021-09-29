using Microsoft.Extensions.DependencyInjection;
using PSETIME_BACK.DAL.DAOs.IDAO.GlobalConfigs;
using PSETIME_BACK.DAL.DAOs.IDAO.Imports;
using PSETIME_BACK.DAL.DAOs.IDAO.UserManager;
using PSETIME_BACK.DAL.DAOs.ImplDAO.GlobalConfigs;
using PSETIME_BACK.DAL.DAOs.ImplDAO.Imports.NewFolder;
using PSETIME_BACK.DAL.DAOs.ImplDAO.UserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            #region UserManager
            services.AddScoped<IUserGroupsDao, UserGroupsDao>();

            #endregion

            #region RevendPerms

            #endregion

            return services;
        }

    }
}
