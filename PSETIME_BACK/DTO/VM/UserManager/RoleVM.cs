using PSETIME_BACK.DTO.VBM.UserManager;
using System;
using System.Collections.Generic;

namespace PSETIME_BACK.DTO.VM.UserManager
{
    public class RoleVM
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public List<UserClaim> Claims { get; set; }
    }
}
