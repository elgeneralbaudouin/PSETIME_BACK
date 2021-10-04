using Newtonsoft.Json;
using PSETIME_BACK.DAL.Models.Entities.GlobalConfigs;
using System;
using System.Collections.Generic;

namespace PSETIME_BACK.DTO.VM.GlobalConfigs
{
    /// <summary>
    ///     VM
    /// </summary>
    public class GlobalConfigsVM : BaseVM<int>
    {
        [JsonProperty("start_time")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndDate { get; set; }
    }

    public static class GlobalConfigsExtention
    {
        /// <summary>
        ///     serialize list of objects
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<GlobalConfigsVM> ToVMs(this List<GlobalConfig> entities)
        {
            List<GlobalConfigsVM> resps = new List<GlobalConfigsVM>();
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
        public static GlobalConfigsVM ToVM(this GlobalConfig entity)
        {
            // construction
            var model = new GlobalConfigsVM()
            {
                Id = entity.Id,
                Code = entity.Code,
                Description = entity.Description,
                EndDate = entity.EndDate,
                StartDate = entity.StartDate
            };

            return model;
        }

    }
}
