using Microsoft.EntityFrameworkCore;
using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms;
using System.Collections.Generic;
using System.Linq;

namespace PSETIME_BACK.DAL.DAOs.ImplDAO.RevendPerms
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
                IEnumerable<PermissionUser> query = context.PermissionUsers
                    .Include(t => t.PermissionsStatus)
                    .Where(t => t.IsActive);
                return query.ToList();
            }

        }
    }

}
