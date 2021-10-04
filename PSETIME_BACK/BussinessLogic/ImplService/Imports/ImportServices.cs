using PSETIME_BACK.BussinessLogic.IService.Imports;
using PSETIME_BACK.DAL.DAOs.IDAO.Imports;
using PSETIME_BACK.DAL.Models.Entities.UserTimeImport;
using System.Collections.Generic;

namespace PSETIME_BACK.BussinessLogic.ImplService.Imports
{
    /// <summary>
    ///     import services
    /// </summary>
    public class ImportServices : IImportServices
    {

        // DI
        private readonly IUserTimeDao _importationDao;

        public ImportServices(IUserTimeDao importationDao)
        {
            _importationDao = importationDao;
        }

        /// <summary>
        ///     get all usertime by state 
        /// </summary>
        /// <param name="IsActive">if entry is in good state</param>
        /// <returns></returns>
        public List<UserTime> GetAll(bool IsActive = true)
        {
            var response = _importationDao.GetAll(IsActive);
            return response;
        }
    }
}
