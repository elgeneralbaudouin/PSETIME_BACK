using PSETIME_BACK.DAL.DAOs.IDAO.UserManager;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
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
    }
}
