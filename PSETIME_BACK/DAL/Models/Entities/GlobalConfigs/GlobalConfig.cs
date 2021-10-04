using Newtonsoft.Json;
using PSETIME_BACK.DAL.Models.Entities.UserManager;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSETIME_BACK.DAL.Models.Entities.GlobalConfigs
{
    /// <summary>
    ///     Configuration globale des groupes utilisateur
    ///     Heure de calcule et autres.....
    /// </summary>
    /// 
    [Table("config_t_global_config")]
    public class GlobalConfig : BaseEntity
    {
        [Column("date_debut")]
        public DateTime StartDate { get; set; }

        [Column("date_fin")]
        public DateTime EndDate { get; set; }

        [JsonIgnore]
        public virtual UserGroups UserGroups { get; set; }
    }
}
