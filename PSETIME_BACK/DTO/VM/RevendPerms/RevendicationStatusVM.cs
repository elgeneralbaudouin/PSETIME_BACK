using Newtonsoft.Json;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DTO.VM.RevendPerms
{
    public class RevendicationStatusVM : BaseVM<int>
    {

        public DateTime ResponseDate { get; set; }

        [MaxLength(300)]
        [JsonProperty("etat")]
        public String Name { get; set; }

    }


    public static class RevendicationStatusExtention
    {

        /// <summary>
        ///     serialize list of objects
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RevendicationStatusVM> ToVMs(this List<RevendicationStatus> entities)
        {
            List<RevendicationStatusVM> resps = new List<RevendicationStatusVM>();
            foreach (var item in entities)
            {
                resps.Add(item.ToVM());
            }

            return resps;
        }

        /// <summary>
        ///     serialize one object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static RevendicationStatusVM ToVM(this RevendicationStatus entity)
        {
            // construction
            var model = new RevendicationStatusVM()
            {
                Id = entity.Id,
                Code = entity.Code,
                Description = entity.Description,
                Name = entity.Name
            };

            return model;
        }

    }

}
