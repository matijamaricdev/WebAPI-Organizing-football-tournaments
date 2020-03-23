using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZavrsniRad.Models
{
    public class Županija
    {
        [Key]
        public int Id { get; set; }

        public string Ime { get; set; }

        public int DržavaId { get; set; }
        public Država Država { get; set; }

        public ICollection<Općina> Općine { get; set; }
        // 1 država ima više županija, u županiji biraš FK od države.
    }
}
