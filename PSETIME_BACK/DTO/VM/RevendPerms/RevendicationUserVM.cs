using Newtonsoft.Json;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DTO.VM.RevendPerms
{
    public class RevendicationUserVM : BaseVM<int>
    {
        [JsonProperty("objets")]
        public String Objet { get; set; }

        [JsonProperty("pieces_Jointes")]
        public String Enclosed { get; set; }
    }

    public static class RevendicationUserExtention
    {
        /// <summary>
        ///     serialize list of objects
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RevendicationUserVM> ToVMs(this List<RevendicationUser> entities)
        {
            List<RevendicationUserVM> resps = new List<RevendicationUserVM>();
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
        public static RevendicationUserVM ToVM(this RevendicationUser entity)
        {
            // construction
            var model = new RevendicationUserVM()
            {
                Id = entity.Id,
                Code = entity.Code,
                Description = entity.Description,
                Objet = entity.Name,
                Enclosed = entity.Enclosed
            };

            return model;
        }

    }
}
