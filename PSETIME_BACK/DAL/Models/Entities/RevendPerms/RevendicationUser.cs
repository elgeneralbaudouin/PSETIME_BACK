using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSETIME_BACK.DAL.Models.Entities.RevendPerms
{
    /// <summary>
    /// cette classe permet de gerer 
    /// les revendications des differents 
    /// utilisateurs de la plateforme
    /// </summary>

    [Table("adm_t_reven_user")]
    public class RevendicationUser : BaseEntity
    {
        /// <summary>
        ///     cle etrangere et config de la cle
        /// </summary>
        [Column("revenUser_id")]
        [ForeignKey("RevendicationStatus")]
        public int RevendicationStatusId { get; set; }

        [Column("objet")]
        public override String Description { get; set; }

        [Column("piece_jointe")]
        public String Enclosed { get; set; }

        [JsonIgnore]
        public virtual RevendicationStatus RevendicationStatus { get; set; }
    }
}
