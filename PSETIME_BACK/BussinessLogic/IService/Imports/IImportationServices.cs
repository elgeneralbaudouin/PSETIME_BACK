using PSETIME_BACK.DAL.Models.Entities.UserTimeImport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.BussinessLogic.IService.Imports
{
    public interface IImportationServices
    {
        List<ImportTimeUser> GetAll(bool IsActive = true);
    }
}
