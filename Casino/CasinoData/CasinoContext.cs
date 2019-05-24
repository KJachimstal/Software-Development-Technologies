using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public class CasinoContext : DbContext
    {
        public CasinoContext() : base() { }

       public DbSet<Client> Clients { get; set; }
       public DbSet<Game> Games { get; set; }
       public DbSet<GameDetails> GamesDetails { get; set; }
       public DbSet<Participation> Participations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<CasinoContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
