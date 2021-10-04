using PSETIME_BACK.DAL.Models.Entities.UserTimeImport;
using System.Collections.Generic;

namespace PSETIME_BACK.BussinessLogic.IService.Imports
{
    public interface IImportServices
    {
        List<UserTime> GetAll(bool IsActive = true);
    }
}
