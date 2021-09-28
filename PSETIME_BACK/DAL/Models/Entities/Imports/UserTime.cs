using Newtonsoft.Json;
using PSETIME_BACK.DAL.Models.Entities.UserManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.Models.Entities.UserTimeImport
{

    /// <summary>
    ///     importation des heures journalier de chaque employes
    /// </summary>
    ///

    [Table("Import_t_user_Import")]
    public class UserTime : BaseEntity
    {

        [Column("heure_d_arrive")]
        public DateTime TimeWorkCome { get; set; }

        [Column("heure_de_depart")]
        public DateTime TimeWorkBack { get; set; }


        /// <summary>
        /// les UserComptes sera le modules de gestion des utilisateurs
        /// il est la cle etrangere id_utilisateur dans notre diagramme de classe
        /// </summary
        /// 

        //[JsonIgnore]
        //public virtual Users User { get; set; }
    }
}
