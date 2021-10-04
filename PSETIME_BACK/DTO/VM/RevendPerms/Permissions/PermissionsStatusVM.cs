using Newtonsoft.Json;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms.Permissions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DTO.VM.RevendPerms.Permissions
{
    public class PermissionsStatusVM : BaseVM<int>
    {
      
        public DateTime ResponseDate { get; set; }

        [MaxLength(300)]
        [JsonProperty("etat")]
        public String Name { get; set; }
    }

    public static class PermissionsStatusExtention
    {

        /// <summary>
        ///     serialize list of objects
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<PermissionsStatusVM> ToVMs(this List<PermissionsStatus> entities)
        {
            List<PermissionsStatusVM> resps = new List<PermissionsStatusVM>();
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
        public static PermissionsStatusVM ToVM(this PermissionsStatus entity)
        {
            // construction
            var model = new PermissionsStatusVM()
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
