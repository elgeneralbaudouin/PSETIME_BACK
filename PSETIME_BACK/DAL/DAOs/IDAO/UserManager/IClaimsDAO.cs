using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models.Entities.UserManager;
using System.Collections.Generic;

namespace PSETIME_BACK.DAL.DAOs.IDAO.UserManager
{
    public interface IClaimsDao : IRepository<Claims>
    {
        public IEnumerable<Claims> GetPrivllegesByParentId(int parentId);
        public IEnumerable<Claims> GetClaimsMenuParentPriv();
    }
}
