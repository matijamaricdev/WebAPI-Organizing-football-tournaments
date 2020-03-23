using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZavrsniRad.Models;

namespace ZavrsniRad.Models
{
    public class ZavrsniRadContext : DbContext
    {
        public ZavrsniRadContext(DbContextOptions<ZavrsniRadContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<Država> Države { get; set; }

        public DbSet<Igrač> Igrači { get; set; }

        public DbSet<Nagrada> Nagrade { get; set; }

        public DbSet<Natjecanja> Natjecanje { get; set; }

        public DbSet<Općina> Općine { get; set; }

        public DbSet<Tim> Timovi { get; set; }

        public DbSet<Županija> Županije { get; set; }
    }
}
