using Newtonsoft.Json;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DTO.VM.RevendPerms
{
    public class PermissionUserVM : BaseVM<int>
    {

        [MaxLength(300)]
        public String Name { get; set; }
    }

    public static class PermissionUserExtention
    {
        /// <summary>
        ///     serialize list of objects
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static PermissionUserVM ToVM (this PermissionUser entity)
        {
          

            var model = new PermissionUserVM()
            {
                Name = entity.Name,
                Code = entity.Code,
                Description = entity.Description,
                Id = entity.Id
            };

            if (entity.PermissionsStatus != null)
            {
                model.Name = entity.PermissionsStatus.Name;
            }
            return model;
        }

        /// <summary>
        ///     serialize one object
        /// </summary>
        /// <param name="entity"></param>
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

    }
}
