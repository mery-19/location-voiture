using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationVoiture.Models
{
    public class Voiture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_voiture { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int id_marque { get; set; }

        [ForeignKey("id_marque")]
        public virtual Marque Marque { get; set; }

        public int? id_offre { get; set; }

        [ForeignKey("id_offre")]
        public virtual Offre Offre { get; set; }

        [Display(Name = "Nombre de passagers")]
        public int nb_passagers { get; set; }

        [Display(Name = "Couleur")]
        public string couleur { get; set; }

        [Display(Name = "Prix")]
        public string prix { get; set; }

        [Display(Name = "Photo")]
        public string photo { get; set; }

        [Display(Name = "Disponible")]
        public bool disponible { get; set; }

        [Display(Name = "Anné")]
        public int anne { get; set; }

        [Display(Name = "Km")]
        public decimal km { get; set; }

        public DateTime date_ajout { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}