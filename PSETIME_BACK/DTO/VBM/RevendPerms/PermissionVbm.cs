using PSETIME_BACK.DAL.Models.Entities.RevendPerms.Permissions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DTO.VBM.RevendPerms
{
    public class PermissionVbm : BaseVbm
    {

        [MaxLength(300)]
        public String Name { get; set; }
    }

    public static class PermissionExtention
    {
        /// <summary>
        ///     use to bind config class instance
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public static PermissionsStatus ToEntity(this PermissionVbm model)
        {
            var entity = new PermissionsStatus()
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
        /// <param name="PermissionsStatusId"></param>
        /// <returns></returns>
        public static PermissionUser ToEntity(this PermissionVbm model, int PermissionsStatusId)
        {
            var entity = new PermissionUser()
            {
                PermissionsStatusId = PermissionsStatusId,
                Name = model.Name,
                Code = model.Name,
                Description = model.Description,
            };

            return entity;
        }

    }

}
