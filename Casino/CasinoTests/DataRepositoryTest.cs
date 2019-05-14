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
    public class DataRepositoryTest
    {
        [TestMethod]
        public void TestDataRepository()
        {
            DateTimeOffset date = new DateTimeOffset();
            Client client1 = new Client(1, "Adam", "Mały");
            Game game = new Game(4, "Poker królewski", Game.GameType.POKER);
            GameDetail gameDetail = new GameDetail(game, date, 400d);
            Participation participation = new Participation(client1, gameDetail, 500);

            List<Client> clients = new List<Client>();
            clients.Add(client1);

            Dictionary<int, Game> games = new Dictionary<int, Game>();
            games.Add(1, game);

            ObservableCollection<GameDetail> gameDetails = new ObservableCollection<GameDetail>();
            gameDetails.Add(gameDetail);

            List<Participation> participations = new List<Participation>();
            participations.Add(participation);

            DataContext dataContext = new DataContext(clients, games, gameDetails, participations);

            IDataSource dataSource;

            DataRepository dataRepository = new DataRepository(dataContext);


        }
    }
}
