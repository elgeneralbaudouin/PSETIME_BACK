using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

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
        [MaxLength(100)]
        public virtual String Name { get; set; }

        [JsonProperty("code")]
        [MaxLength(100)]
        public virtual String Code { get; set; }

        [JsonProperty("description")]
        [MaxLength(100)]
        public virtual String Description { get; set; }

    }
}
