using System;
using System.Collections.Generic;

namespace PSETIME_BACK.DTO.VM.UserManager
{
    public class AllClaimsVM
    {
        public List<ClaimsVM> ClaimsMenu { get; set; }
        public List<ClaimsPrivilleges> ClaimsPrivs { get; set; }
    }

    public class ClaimsPrivilleges
    {
        public string Code { get; set; }
        public IEnumerable<String> Privilleges { get; set; }
    }
}
