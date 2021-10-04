using Microsoft.EntityFrameworkCore;
using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms.Permissions;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.DAOs.ImplDAO.RevendPerms.Permissions
{
    public class PermissionUserDao : Repository<PermissionUser>, IPermissionUserDao
    {

        /// <summary>
        ///     Constructeur par default
        /// </summary>
        public PermissionUserDao() : base(Ctx)
        {

        }

        public override List<PermissionUser> GetAll(bool active)
        {

            using (ApplicationDBContext context = Ctx)
            {
                IEnumerable<PermissionUser> query = context.PermissionUser
                    .Include(t => t.PermissionsStatus)
                    .Where(t => t.IsActive);
                return query.ToList();
            }

        }
    }

}
