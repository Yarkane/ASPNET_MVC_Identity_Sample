using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaysTracker.Models
{  // TODO test changements
    public class Regime
    {
        [Key]
        public int RegimeId { get; set; }
        public string Nom { get; set; }

        public ICollection<Pays> ListePays { get; set; }  // Pour foreign key
    }
}
