using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZavrsniRad.Models
{
    public class Tim
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        [Range(0, 6, ErrorMessage = "Unesite broj veći od 0 a manji od 6")]
        public int Broj_igraca { get; set; }

        [Required]
        public bool Kotizacija { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Unesite godine igranja ovoga turnira")]
        public int Godine_igranja { get; set; }

        public ICollection<Igrač> Igrači { get; set; }
    }
}
