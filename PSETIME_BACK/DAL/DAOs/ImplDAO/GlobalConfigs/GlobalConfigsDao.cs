using PSETIME_BACK.DAL.DAOs.IDAO.GlobalConfigs;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models.Entities.GlobalConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.DAOs.ImplDAO.GlobalConfigs
{
    /// <summary>
    ///     
    /// </summary>
    public class GlobalConfigsDao : Repository<GlobalConfig>, IGlobalConfigsDao
    {
        /// <summary>
        ///     Constructeur par default
        /// </summary>
        public GlobalConfigsDao() : base(Ctx)
        {

        }

    }
}
