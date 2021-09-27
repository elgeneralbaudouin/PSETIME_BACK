using PSETIME_BACK.DAL.DAOs.IDAO.Imports;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models.Entities.UserTimeImport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.DAOs.ImplDAO.Imports.NewFolder
{
    public class ImportationDao : Repository<ImportTimeUser>, IImportationDao
    {

        /// <summary>
        ///     Constructeur par default
        /// </summary>
        public ImportationDao() : base(Ctx)
        {

        }
    }
}
