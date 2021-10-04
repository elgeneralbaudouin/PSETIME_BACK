using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms.Revendications;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms.Revendications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.DAOs.ImplDAO.RevendPerms.Revendications
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
