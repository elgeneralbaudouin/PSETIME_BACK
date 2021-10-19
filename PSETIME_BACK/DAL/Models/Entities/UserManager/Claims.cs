using System.ComponentModel.DataAnnotations;

namespace PSETIME_BACK.DAL.Models.Entities.UserManager
{
    public class Claims : BaseEntity
    {
        [MaxLength(100)]
        public string ClaimsValue { get; set; }
        [MaxLength(100)]
        public string ClaimsType { get; set; }
        public int? ParentId { get; set; }

    }
}
