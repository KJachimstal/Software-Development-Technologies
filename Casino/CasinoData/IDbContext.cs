using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public interface IDbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Game> Games { get; set; }
        DbSet<GameDetails> GamesDetails { get; set; }
        DbSet<Participation> Participations { get; set; }
        void SaveChanges();
    }
}
