using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZavrsniRad.Models
{
    public class Država
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        public ICollection<Županija> Županije { get; set; }
    }
}
