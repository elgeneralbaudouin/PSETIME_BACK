using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.Models.Entities.RevendPerms.Permissions
{
    [Table("adm_t_perm_user")]
    public class PermissionUser : BaseEntity
    {

        /// <summary>
        ///     cle etrangere et config de la cle
        /// </summary>
        
        [Column("perm_status_id")]
        [ForeignKey("PermissionsStatus")]
        public Int32 PermissionsStatusId { get; set; }

        [Column("date_demande")]
        public DateTime RequestDate { get; set; }

        [Column("date_reponse")]
        public DateTime ResponseDate { get; set; }

        [Column("reponse")]
        [MaxLength(300)]
        public String Response { get; set; }

        [JsonIgnore]
        public virtual PermissionsStatus PermissionsStatus { get; set; }
    }
}
