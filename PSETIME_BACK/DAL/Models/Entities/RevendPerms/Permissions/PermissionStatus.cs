using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.Models.Entities.RevendPerms.Permissions
{

    /// <summary>
    /// cette classe permet de gerer 
    /// les status des permissions des differents 
    /// utilisateurs de la plateforme
    /// </summary>

    [Table("adm_t_permis_status")]
    public class PermissionStatus : BaseEntity
    {
        [Column("etat_permis")]
        public override String Name { get; set; }

        [JsonIgnore]
        public virtual PermissionUser PermissionUser { get; set; }

    }
}
