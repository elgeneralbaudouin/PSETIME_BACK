using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms;

namespace PSETIME_BACK.DAL.DAOs.ImplDAO.RevendPerms
{
    public class RevendicationStatusDao : Repository<RevendicationStatus>, IRevendicationStatusDao
    {

        /// <summary>
        ///     Constructeur par default
        /// </summary>
        public RevendicationStatusDao() : base(Ctx)
        {

        }


    }
}
