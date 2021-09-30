using PSETIME_BACK.DAL.Models.Entities.GlobalConfigs;
using PSETIME_BACK.DAL.Models.Entities.UserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DTO.VBM.UserManager
{
    public class GroupsVbm : BaseVbm
    {
        public DateTime StardDate { get; set; }
        public DateTime EndDate { get; set; }
    }


    public static class GroupExtention
    {
        /// <summary>
        ///     use to bind config class instance
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static GlobalConfig ToEntity(this GroupsVbm model)
        {
            var entity = new GlobalConfig()
            {
                StartDate = model.StardDate,
                EndDate = model.EndDate,
                Name = model.Name,
                Code = model.Name,
                Description = model.Description,
            };

            return entity;
        }

        /// <summary>
        ///     use to bind config class instance
        /// </summary>
        /// <param name="model"></param>
        /// <param name="GlobalConfigId"></param>
        /// <returns></returns>
        public static UserGroups ToEntity (this GroupsVbm model, int GlobalConfigId)
        {
            var entity = new UserGroups()
            {
                GlobalConfigId = GlobalConfigId,
                Name = model.Name,
                Code = model.Name,
                Description = model.Description,
            };

            return entity;
        }

    }
}
