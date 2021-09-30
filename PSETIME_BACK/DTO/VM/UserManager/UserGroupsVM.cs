using PSETIME_BACK.DAL.Models.Entities.UserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DTO.VM.UserManager
{
    public class UserGroupsVM : BaseVM<int>
    {
        public DateTime StardDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public static class GroupsExtention
    {
        public static UserGroupsVM ToVM (this UserGroups entity)
        {
            var model = new UserGroupsVM()
            {
                Name = entity.Name,
                Code = entity.Code,
                Description = entity.Description,
                Id = entity.Id
            };

            if (entity.GlobalConfig != null)
            {
                model.StardDate = entity.GlobalConfig.StartDate;
                model.EndDate = entity.GlobalConfig.EndDate;
            }

            return model;
        }


        public static List<UserGroupsVM> ToVMs(this List<UserGroups> entities)
        {
            List<UserGroupsVM> resps = new List<UserGroupsVM>();
            foreach (var item in entities)
            {
                resps.Add(item.ToVM());
            }

            return resps;
        }


    }
}
