using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DTO.VBM
{
    public class BaseVbm
    {
        //[JsonProperty("name")]
        public virtual String Name { get; set; }

        //[JsonProperty("description")]
        public virtual String Description { get; set; }
    }
}
