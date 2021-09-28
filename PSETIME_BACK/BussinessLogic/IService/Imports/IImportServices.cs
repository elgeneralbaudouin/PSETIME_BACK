using PSETIME_BACK.DAL.Models.Entities.UserTimeImport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.BussinessLogic.IService.Imports
{
    public interface IImportServices
    {
        List<UserTime> GetAll(bool IsActive = true);
    }
}
