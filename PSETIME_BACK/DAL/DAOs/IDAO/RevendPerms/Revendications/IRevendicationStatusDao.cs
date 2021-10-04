using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms.Revendications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms.Revendications
{
    public interface IRevendicationStatusDao : IRepository<RevendicationStatus> 
    {
    }
}
