using System.ComponentModel.DataAnnotations;

namespace PSETIME_BACK.DTO.VBM.UserManager
{
    public class LoginVbm
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }
    }
}
