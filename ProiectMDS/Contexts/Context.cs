using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectMDS.Models;

namespace ProiectMDS.Contexts
{
    public class Context: DbContext
    {
        public DbSet<Utilizator> Utilizatori { get; set; }
        public DbSet<Fotografie> Fotografii { get; set; }
        public DbSet<Rezervare> Rezervari { get; set; }
        public DbSet<Vacanta> Vacante { get; set; }
        public DbSet<TichetMasa> TicheteMasa { get; set; }
        public DbSet<Restaurant> Restaurante { get; set; }
        public DbSet<Meniu> Meniuri { get; set; }
        public DbSet<Mancare> Mancaruri { get; set; }
        public DbSet<Bilet> Bilete { get; set; }
        public DbSet<Atractie> Atractii { get; set; }
        public DbSet<RezervareCazare> RezervariCazari { get; set; }
        public DbSet<Cazare> Cazari { get; set; }
        public DbSet<Pachet> Pachete { get; set; }
        public DbSet<Facilitate> Facilitati { get; set; }

        public static bool isMigration = true;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (isMigration)
                optionsBuilder.UseSqlServer(@"Server=.\;Database=DBProiectMDSAplicatieVacanta;Trusted_Connection=True");
        }

        public Context()
        {
            //construiesc
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
