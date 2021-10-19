using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace PSETIME_BACK.DAL.Models.Entities.UserManager
{
    public class Users : IdentityUser
    {
        [MaxLength(100)]
        [JsonIgnore]
        public string CreatedBy { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        [JsonIgnore]
        public string UpdatedBy { get; set; }
        [JsonIgnore]
        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }

        [Required]
        [JsonIgnore]
        public Boolean IsActive { get; set; }

        public void BaseUpdate(string userId, bool isActive)
        {
            this.UpdatedAt = DateTime.Now;
            this.UpdatedBy = userId;
            this.IsActive = isActive;
        }

        public void BaseCreate(string userId, bool isActive)
        {
            this.CreatedAt = DateTime.Now;
            this.CreatedBy = userId;
            this.UpdatedAt = DateTime.Now;
            this.UpdatedBy = userId;
            this.IsActive = isActive;
        }

    }
}
