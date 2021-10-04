using Newtonsoft.Json;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DTO.VBM.RevendPerms
{
    public class PermissionVbm : BaseVbm
    {
        [JsonProperty("permission_status_id")]
        public int PermissionsStatusId { get; set; }

        [MaxLength(300)]
        [JsonProperty("name")]
        public override String Name { get; set; }

        [MaxLength(500)]
        [JsonProperty("object")]
        public override String Description { get; set; }
    }

    public static class PermissionExtention
    {
        /// <summary>
        ///     use to bind permission class instance
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public static PermissionsStatus ToEntity(this PermissionVbm model)
        {
            var entity = new PermissionsStatus()
            {
                Name = model.Name,
                Code = model.Name.ToUpper(),
                Description = model.Description,
            };

            return entity;
        }

        /// <summary>
        ///     use to bind config class instance
        /// </summary>
        /// <param name="model"></param>
        /// <param name="PermissionsStatusId"></param>
        /// <returns></returns>
        public static PermissionUser ToEntity(this PermissionVbm model, int PermissionsStatusId)
        {
            var entity = new PermissionUser()
            {
                PermissionsStatusId = PermissionsStatusId,
                Name = model.Name,
                Code = model.Name.ToUpper(),
                Description = model.Description,
            };

            return entity;
        }

    }

}
