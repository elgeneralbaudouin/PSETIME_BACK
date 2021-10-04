using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
