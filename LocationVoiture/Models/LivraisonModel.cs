using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LocationVoiture.Models
{
    public class Livraison
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_livraison { get; set; }

        [Display(Name = "Libele")]
        public string libele { get; set; }

        public virtual ICollection<Livraison> Livraisons { get; set; }

    }
}