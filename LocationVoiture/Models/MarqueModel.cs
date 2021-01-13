using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationVoiture.Models
{
    public class Marque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_marque { get; set; }

        [Display(Name = "Libele")]
        public string libele { get; set; }

        public DateTime date_ajout { get; set; }

        public virtual ICollection<Voiture> Voitures { get; set; }
    }
}