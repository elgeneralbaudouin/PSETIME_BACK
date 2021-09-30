using Newtonsoft.Json;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DTO.VM.RevendPerms
{
    public class PermissionUserVM : BaseVM<int>
    {
        [JsonProperty("date_demande")]
        public DateTime RequestDate { get; set; }

        [JsonProperty("date_reponse")]
        public DateTime ResponseDate { get; set; }

        [JsonProperty("reponse")]
        public String Response { get; set; }
    }

    public static class PermissionUserExtention
    {
        /// <summary>
        ///     serialize list of objects
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<PermissionUserVM> ToVMs(this List<PermissionUser> entities)
        {
            List<PermissionUserVM> resps = new List<PermissionUserVM>();
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
        public static PermissionUserVM ToVM(this PermissionUser entity)
        {
            // construction
            var model = new PermissionUserVM()
            {
                Id = entity.Id,
                Code = entity.Code,
                Description = entity.Description,
                RequestDate = entity.RequestDate,
                ResponseDate = entity.ResponseDate,
                Response = entity.Response
            };

            return model;
        }

    }
}
