using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms.Permissions
{
    public interface IPermissionsStatusDao : IRepository<PermissionsStatus>
    {
    }
}
