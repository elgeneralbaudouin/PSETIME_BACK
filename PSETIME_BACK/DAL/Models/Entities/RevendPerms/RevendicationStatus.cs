﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.Models.Entities.RevendPerms
{

    /// <summary>
    /// cette classe permet de gerer 
    /// les status des revendications des differents 
    /// utilisateurs de la plateforme
    /// </summary>

    [Table("adm_t_reven_atatut")]
    public class RevendicationStatus : BaseEntity
    {
        

        [Column("etat_reven")]
        [MaxLength(100)]
        public override String Name { get; set; }

        [JsonIgnore]
        public virtual RevendicationUser RenvendicationUser { get; set; }
    }
}