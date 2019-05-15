using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasinoLibrary;
using CasinoData;
using System.Collections.ObjectModel;

namespace CasinoTests
{
    [TestClass]
    public class DataContextTest
    {
        [TestMethod]
        public void TestDataContext()
        {
            DateTimeOffset date = new DateTimeOffset();
            Client client1 = new Client(1, "Adam", "Mały");
            Client client2 = new Client(2, "Michał", "Spory");
            Game game = new Game(4, "Poker królewski", Game.GameType.POKER);
            GameDetails gameDetail = new GameDetails(game, date, 400d);
            Participation participation = new Participation(client1, gameDetail, 500);

            List<Client> clients = new List<Client>();
            clients.Add(client1);
            clients.Add(client2);

            Dictionary<int, Game> games = new Dictionary<int, Game>();
            games.Add(1, game);

            ObservableCollection<GameDetails> gameDetails = new ObservableCollection<GameDetails>();
            gameDetails.Add(gameDetail);

            List<Participation> participations = new List<Participation>();
            participations.Add(participation);

            DataContext dataContext = new DataContext(clients, games, gameDetails, participations);

            //Assertions
            Assert.AreEqual(2, dataContext.Clients.Count);
            Assert.AreEqual(1, dataContext.Games.Count);
            Assert.AreEqual(1, dataContext.GameDetails.Count);
            Assert.AreEqual(1, dataContext.Participations.Count);
        }
    }
}
