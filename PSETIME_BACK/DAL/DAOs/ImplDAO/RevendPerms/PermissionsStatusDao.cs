using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.DAOs.ImplDAO.RevendPerms
{
    public class PermissionsStatusDao : Repository<PermissionsStatus>, IPermissionsStatusDao
    {

        /// <summary>
        ///     Constructeur par default
        /// </summary>
        public PermissionsStatusDao() : base(Ctx)
        {

        }

    }
}
