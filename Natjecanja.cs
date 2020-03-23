using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZavrsniRad.Models
{
    public class Natjecanja
    {
        [Key]
        public int Id { get; set; }

        public string Ime { get; set; }

        public DateTime Datum_odigravanja { get; set; }

        public int Ukupno_timova { get; set; } = 4;
    }
}
