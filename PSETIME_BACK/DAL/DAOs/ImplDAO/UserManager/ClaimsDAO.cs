using PSETIME_BACK.DAL.DAOs.IDAO.UserManager;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models.Entities.UserManager;
using System.Collections.Generic;
using System.Linq;

namespace PSETIME_BACK.DAL.DAOs.ImplDAO.UserManager
{
    public class ClaimsDao : Repository<Claims>, IClaimsDao
    {
        public ClaimsDao() : base(Ctx)
        {

        }

        public IEnumerable<Claims> GetClaimsMenuParentPriv()
        {
            var query = GetByQuery(t => t.IsActive && t.ClaimsType == "menu");

            return (IEnumerable<Claims>)query.ToList();
        }

        public IEnumerable<Claims> GetPrivllegesBycode(string code)
        {

            var query = GetByQuery(t => t.IsActive).GroupBy(t => t.Code);

            return (IEnumerable<Claims>)query.ToList();
        }

        public IEnumerable<Claims> GetPrivllegesByParentId(int parentId)
        {
            var query = GetByQuery(t => t.IsActive && t.ParentId == parentId);

            return (IEnumerable<Claims>)query.ToList();
        }
    }
}
