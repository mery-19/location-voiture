using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationVoiture.Models
{
    public class Offre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_offre { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Libele")]
        public string libele { get; set; }

        [Display(Name = "Taux de remise")]
        public int taux_remise { get; set; }

        [Display(Name = "Date d'éxpiration")]
        public DateTime date_expiration { get; set; }

        public DateTime date_ajout { get; set; }

        public virtual ICollection<Voiture> Voitures { get; set; }

    }
}