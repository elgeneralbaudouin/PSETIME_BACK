using System;

namespace PSETIME_BACK.DTO.VBM.UserManager
{
    public class UserFilter
    {
        public String Email { get; set; }
        public String UserName { get; set; }
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public String LastName { get; set; }
        public int Status { get; set; }
    }
}
