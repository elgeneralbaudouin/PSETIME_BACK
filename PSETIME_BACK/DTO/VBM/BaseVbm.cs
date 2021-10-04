using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DTO.VBM
{
    public class BaseVbm
    {
        //[JsonProperty("name")]

        [MaxLength(100)]
        public virtual String Name { get; set; }

        //[JsonProperty("description")]
        [MaxLength(100)]
        public virtual String Description { get; set; }
    }
}
