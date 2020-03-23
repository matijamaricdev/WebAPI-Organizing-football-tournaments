using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZavrsniRad.Models
{
    public class Općina
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        public int ŽupanijaId { get; set; }
        public Županija Županija { get; set; }
    }
}
