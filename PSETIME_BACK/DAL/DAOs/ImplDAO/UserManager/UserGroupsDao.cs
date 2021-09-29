using Microsoft.EntityFrameworkCore;
using PSETIME_BACK.DAL.DAOs.IDAO.UserManager;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models;
using PSETIME_BACK.DAL.Models.Entities.UserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.DAOs.ImplDAO.UserManager
{
    public class UserGroupsDao : Repository<UserGroups>, IUserGroupsDao
    {
        public UserGroupsDao() : base(Ctx)
        {

        }


        public override List<UserGroups> GetAll(bool active)
        {
            using (ApplicationDBContext context = Ctx)
            {
                IEnumerable<UserGroups> query = context.UserGroups
                    .Include(t => t.GlobalConfig)
                    .Where(t => t.IsActive);
                return query.ToList();
            }
        }
    }

}