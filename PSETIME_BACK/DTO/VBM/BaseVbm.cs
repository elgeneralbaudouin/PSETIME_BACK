using System;
using System.ComponentModel.DataAnnotations;

namespace PSETIME_BACK.DTO.VBM
{
    public class BaseVbm
    {

        [MaxLength(100)]
        public virtual String Name { get; set; }

        [MaxLength(100)]
        public virtual String Description { get; set; }
    }
}
