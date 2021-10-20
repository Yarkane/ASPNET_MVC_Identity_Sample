using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaysTracker.Models
{
    public class Pays
    {
        [Key]
        public string Nom { get; set; }
        public string Dirigeant { get; set; }
        public double Surface { get; set; }
        public double Population { get; set; }

        // Foreign Key Regime
        [ForeignKey("Regime")]
        public int RegimeId { get; set; }
        public Regime Regime { get; set; }
    }
}
