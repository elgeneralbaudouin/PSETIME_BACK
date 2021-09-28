using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DTO.VM
{
    /// <summary>
    ///     Base viewmodel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseVM<T>
    {
        [JsonProperty("id")]
        public virtual T Id { get; set; }

        [JsonProperty("name")]
        public virtual String  Name { get; set; }

        [JsonProperty("code")]
        public virtual String  Code { get; set; }

        [JsonProperty("description")]
        public virtual String  Description { get; set; }

    }
}
