using PSETIME_BACK.BussinessLogic.IService.Imports;
using PSETIME_BACK.DAL.DAOs.IDAO.Imports;
using PSETIME_BACK.DAL.Models.Entities.UserTimeImport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.BussinessLogic.ImplService.Imports
{
    public class ImportationServices : IImportationServices
    {

        // DI
        private readonly IImportationDao _importationDao;

        public ImportationServices(IImportationDao importationDao)
        {
            _importationDao = importationDao;
        }


        public List<ImportTimeUser> GetAll (bool IsActive = true) 
        {
            var response = _importationDao.GetAll(IsActive);
            return response;
        }
    }
}
