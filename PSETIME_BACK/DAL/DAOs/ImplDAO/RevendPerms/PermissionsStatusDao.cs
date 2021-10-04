using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms;

namespace PSETIME_BACK.DAL.DAOs.ImplDAO.RevendPerms
{
    public class PermissionsStatusDao : Repository<PermissionsStatus>, IPermissionsStatusDao
    {

        /// <summary>
        ///     Constructeur par default
        /// </summary>
        public PermissionsStatusDao() : base(Ctx)
        {

        }

    }
}
