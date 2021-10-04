using PSETIME_BACK.DAL.Models.Entities.RevendPerms.Revendications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DTO.VBM.RevendPerms
{
    public class RevendicationVbm : BaseVbm
    {
        [MaxLength(300)]
        public String Name { get; set; }

    }

    public static class RevendicationExtention
    {
        /// <summary>
        ///     use to bind config class instance
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public static RevendicationStatus ToEntity(this RevendicationVbm model)
        {
            var entity = new RevendicationStatus()
            {
                //  RequestDate = model.RequestDate,
                //  ResponseDate = model.ResponseDate,
                //  Response = model.Response,
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
        public static RevendicationUser ToEntity(this RevendicationVbm model, int RevendicationStatusId)
        {
            var entity = new RevendicationUser()
            {
                RevendicationStatusId = RevendicationStatusId,
                Name = model.Name,
                Code = model.Name,
                Description = model.Description,
            };

            return entity;
        }

    }

}
