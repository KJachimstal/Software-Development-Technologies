using CasinoData;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoTests
{
    class TestContext : DbContext, IDbContext
    {
        public TestContext() : base()
        {
            Database.Delete();
            Database.Create();

            Client client1 = new Client(1, "One", "One");
            Client client2 = new Client(2, "Two", "Two");
            Clients.Add(client1);
            Clients.Add(client2);

            Game game1 = new Game(1, "GameOne", Game.GameType.BRIDGE);
            Game game2 = new Game(2, "GameTwo", Game.GameType.POKER);
            Games.Add(game1);
            Games.Add(game2);

            DateTime localTime1 = new DateTime(2019, 05, 24, 12, 30, 15);
            DateTimeOffset dateTimeOffset1 = new DateTimeOffset(localTime1, TimeZoneInfo.Local.GetUtcOffset(localTime1));

            DateTime localTime2 = new DateTime(2019, 04, 23, 11, 20, 00);
            DateTimeOffset dateTimeOffset2 = new DateTimeOffset(localTime2, TimeZoneInfo.Local.GetUtcOffset(localTime2));

            GameDetails gameDetails1 = new GameDetails(game1, dateTimeOffset1, 100);
            GameDetails gameDetails2 = new GameDetails(game1, dateTimeOffset2, 200);
            GamesDetails.Add(gameDetails1);
            GamesDetails.Add(gameDetails2);

            Participation participation1 = new Participation(client1, gameDetails1, 110);
            Participation participation2 = new Participation(client2, gameDetails2, 220);
            Participations.Add(participation1);
            Participations.Add(participation2);

            SaveChanges();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameDetails> GamesDetails { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public void SaveChanges() => base.SaveChanges();
    }
}
