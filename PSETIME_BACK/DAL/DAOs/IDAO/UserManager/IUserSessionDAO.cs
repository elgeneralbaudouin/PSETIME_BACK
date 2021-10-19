using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models.Entities.UserManager;

namespace PSETIME_BACK.DAL.DAOs.IDAO.UserManager
{
    public interface IUserSessionDao : IRepository<UserSession>
    {
        public UserSession GetByTokenAndUserId(string UserId, string Token);
    }
}
