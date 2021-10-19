using PSETIME_BACK.DAL.DAOs.IDAO.UserManager;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models.Entities.UserManager;
using System.Linq;

namespace PSETIME_BACK.DAL.DAOs.ImplDAO.UserManager
{
    public class UserSessionDao : Repository<UserSession>, IUserSessionDao
    {
        public UserSessionDao() : base(Ctx)
        {

        }

        public UserSession GetByTokenAndUserId(string UserId, string Token)
        {
            var query = GetByQuery(t => t.UserId.Equals(UserId) && t.Token.Equals(Token) && t.IsActive).FirstOrDefault();
            return query;
        }
    }
}
