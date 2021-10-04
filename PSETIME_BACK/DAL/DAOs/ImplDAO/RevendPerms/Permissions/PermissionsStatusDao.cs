using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms.Permissions;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.DAOs.ImplDAO.RevendPerms.Permissions
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
