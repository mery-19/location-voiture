﻿using System;
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

        [Display(Name = "marque", ResourceType = typeof(LocationVoiture.Resources.Models.VoitureModel))]
        public int id_marque { get; set; }

        [ForeignKey("id_marque")]
        public virtual Marque Marque { get; set; }

        [Display(Name = "offre", ResourceType = typeof(LocationVoiture.Resources.Models.VoitureModel))]
        public int? id_offre { get; set; }

        [ForeignKey("id_offre")]
        public virtual Offre Offre { get; set; }

        [Display(Name = "nb_passagers", ResourceType = typeof(LocationVoiture.Resources.Models.VoitureModel))]
        public int nb_passagers { get; set; }

        [Display(Name = "color", ResourceType = typeof(LocationVoiture.Resources.Models.VoitureModel))]
        public string couleur { get; set; }

        [Display(Name = "prix", ResourceType = typeof(LocationVoiture.Resources.Models.VoitureModel))]
        public string prix { get; set; }

        [Display(Name = "photo", ResourceType = typeof(LocationVoiture.Resources.Models.VoitureModel))]
        public string photo { get; set; }

        [Display(Name = "dispo", ResourceType = typeof(LocationVoiture.Resources.Models.VoitureModel))]
        public bool disponible { get; set; }

        [Display(Name = "anne", ResourceType = typeof(LocationVoiture.Resources.Models.VoitureModel))]
        public int anne { get; set; }

        [Display(Name = "km", ResourceType = typeof(LocationVoiture.Resources.Models.VoitureModel))]
        public decimal km { get; set; }

        public DateTime date_ajout { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}