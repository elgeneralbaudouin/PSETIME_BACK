using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.Models.Entities
{
    /// <summary>
    ///  Classe de base de tou(te)s les classes entités du modele de la base de donnée
    /// </summary>
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public virtual string Description { get; set; }

        [MaxLength(100)]
        public virtual string Code { get; set; }
        
        [MaxLength(100)]
        public virtual string Name { get; set; }

        [MaxLength(100)]
        [JsonIgnore]
        public string CreatedBy { get; set; }

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

        /// <summary>
        ///  a utiliser avant toutes mise a jour d une entité en BD
        /// </summary>
        /// <param name="userId"> identitfiant de l 'utilisateur qui fait l action</param>
        /// <param name="isActive"> parametre qui donne de l'etat de l'entrée dans la base de donnée</param>
        public void BaseUpdate(string userId, bool isActive)
        {
            this.UpdatedAt = DateTime.Now;
            this.UpdatedBy = userId;
            this.IsActive = isActive;
        }

        /// <summary>
        ///     a utiliser avant toute insertion dans la base de donnée
        /// </summary>
        /// <param name="userId"> identitfiant de l 'utilisateur qui fait l action</param>
        /// <param name="isActive"> parametre qui donne de l'etat de l'entrée dans la base de donnée</param>
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
