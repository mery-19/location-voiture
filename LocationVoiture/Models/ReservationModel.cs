using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationVoiture.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_reservation { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int id_voiture { get; set; }

        [ForeignKey("id_voiture")]
        public virtual Voiture Voiture { get; set; }

        public int id_livraison { get; set; }

        [ForeignKey("id_livraison")]
        public virtual Livraison Livraison { get; set; }

        [Display(Name = "Date prise en charge")]
        public DateTime date_prise_en_charge { get; set; }

        [Display(Name = "Date de retour")]
        public DateTime date_retour { get; set; }

        [Display(Name = "Lien prise en charge")]
        public string lieu_prise_en_charge { get; set; }

    }
}