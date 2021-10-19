using System;
using System.ComponentModel.DataAnnotations;

namespace PSETIME_BACK.DTO.VBM.UserManager
{
    public class RegisterVbm
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public String Password { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public String ConfirmPassword { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public String UserName { get; set; }
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public String LastName { get; set; }
        public String RoleName { get; set; }
    }
}
