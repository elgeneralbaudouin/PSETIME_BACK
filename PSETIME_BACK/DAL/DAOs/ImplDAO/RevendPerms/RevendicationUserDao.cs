
using Microsoft.EntityFrameworkCore;
using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.DAOs.ImplDAO.RevendPerms
{
    public class RevendicationUserDao : Repository<RevendicationUser>, IRevendicationUserDao
    {
        /// <summary>
        ///     Constructeur par default
        /// </summary>
        public RevendicationUserDao() : base(Ctx)
        {

        }

        public override List<RevendicationUser> GetAll(bool active)
        {

            using (ApplicationDBContext context = Ctx)
            {
                IEnumerable<RevendicationUser> query = context.RevendicationUsers
                    .Include(t => t.RevendicationStatus)
                    .Where(t => t.IsActive);
                return query.ToList();
            }

        }
    }
}
