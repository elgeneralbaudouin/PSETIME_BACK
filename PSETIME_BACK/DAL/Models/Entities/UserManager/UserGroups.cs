using Newtonsoft.Json;
using PSETIME_BACK.DAL.Models.Entities.GlobalConfigs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.Models.Entities.UserManager
{
    /// <summary>
    ///     Classe qui permet de gerer le groupe d utilisateur dans le but 
    ///     de regrouper toutes les utilisateur d un secteur particulier sur lequelle 
    ///     devrai apparaitre des config globle
    /// </summary>
    public class UserGroups : BaseEntity
    {
        /// <summary>
        /// cle etrangere et config de la clé
        /// </summary>
        [Column("config_id")]
        [ForeignKey("GlobalConfig")]
        public int GlobalConfigId { get; set; }

        [JsonIgnore]
        public virtual GlobalConfig GlobalConfig { get; set; }
    }
}
