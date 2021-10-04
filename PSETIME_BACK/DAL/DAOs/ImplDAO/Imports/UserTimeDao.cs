﻿using PSETIME_BACK.DAL.DAOs.IDAO.Imports;
using PSETIME_BACK.DAL.DAOs.RepositoryPattern;
using PSETIME_BACK.DAL.Models.Entities.UserTimeImport;

namespace PSETIME_BACK.DAL.DAOs.ImplDAO.Imports.NewFolder
{
    /// <summary>
    /// classe de d'access a donnée du model UserTime
    /// </summary>
    public class UserTimeDao : Repository<UserTime>, IUserTimeDao
    {

        /// <summary>
        ///     Constructeur par default
        /// </summary>
        public UserTimeDao() : base(Ctx)
        {

        }
    }
}
