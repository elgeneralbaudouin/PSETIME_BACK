using PSETIME_BACK.DAL.Models.Entities.RevendPerms;
using System;
using System.ComponentModel.DataAnnotations;

namespace PSETIME_BACK.DTO.VBM.RevendPerms
{
    public class RevendicationVbm : BaseVbm
    {
        [MaxLength(300)]
        public override String Name { get; set; }

    }

    public static class RevendicationExtention
    {
        /// <summary>
        ///     use to bind config class instance
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public static RevendicationUser ToEntity(this RevendicationVbm model)
        {
            var entity = new RevendicationUser()
            {
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
        /// <param name="RevendicationStatusId"></param>
        /// <returns></returns>
        public static RevendicationUser ToEntity(this RevendicationVbm model, int StatusId)
        {
            var entity = new RevendicationUser()
            {
                RevendicationStatusId = StatusId,
                Name = model.Name,
                Code = model.Name,
                Description = model.Description,
            };

            return entity;
        }

    }

}
