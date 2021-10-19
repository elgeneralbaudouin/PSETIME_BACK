using System;
using System.ComponentModel.DataAnnotations;

namespace PSETIME_BACK.DAL.Models.Entities.UserManager
{
    public class UserSession : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string UserId { get; set; }
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string ClientId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime IssuedDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ExpireDate { get; set; }
        [Required]
        [MaxLength(10000)]
        public string Token { get; set; }
    }
}
