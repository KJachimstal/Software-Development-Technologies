using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasinoLibrary;
using CasinoData;
using System.Collections.ObjectModel;
using CasinoSources;

namespace CasinoTests
{
    [TestClass]
    public class DataRepositoryTest
    {

        public static ConstantSource constantSource = new ConstantSource();
        public static DataRepository dataRepository = new DataRepository(constantSource);
        public static DataContext dataContext = new DataContext();
        
        [TestInitialize]
        public void TestInitialize()
        {
            dataRepository.DataContext = dataContext;
            dataRepository.Fill();
        }

        [TestMethod]
        public void ClientsRepositoryTest()
        {
            // GetAllClient test
            Assert.AreEqual(10, dataRepository.GetAllClients().Count);

            // AddClient test
            Client client = new Client(11, "Anna", "Hanna");
            dataRepository.AddClient(client);
            Assert.AreEqual(11, dataRepository.GetAllClients().Count);

            // GetClient test
            Assert.AreEqual(11, dataRepository.GetClient(11).ClientNumber);

            // UpdateClient test
            Client newClient = new Client(11, "Józek", "Daniel");
            dataRepository.UpdateClient(client, newClient);
            Assert.AreEqual("Józek", dataRepository.GetClient(11).FirstName);

            // DeleteClient test 
            dataRepository.DeleteClient(newClient);
            Assert.IsNull(dataRepository.GetClient(11));
        }

        [TestMethod]
        public void GamesRepositoryTest()
        {
            // GetAllGames test
            Assert.AreEqual(3, dataRepository.GetAllGames().Count);

            // AddGame test
            Game game = new Game(4, "Poker królewski", Game.GameType.POKER);
            dataRepository.AddGame(game);
            Assert.AreEqual(4, dataRepository.GetAllGames().Count);

            // GetGame test
            Assert.AreEqual("Poker królewski", dataRepository.GetGame(4).Name);

            // UpdateGame test
            Game newGame = new Game(4, "Pokerek", Game.GameType.POKER);
            dataRepository.UpdateGame(game, newGame);
            Assert.AreEqual("Pokerek", dataRepository.GetGame(4).Name);

            // DeleteGame test
            Assert.AreEqual(4, dataRepository.GetAllGames().Count);
            dataRepository.DeleteGame(newGame);
            Assert.AreEqual(3, dataRepository.GetAllGames().Count);
        }

        [TestMethod]
        public void GameDetailsReporitoryTest()
        {
            // GetAllGameDetails test
            Assert.AreEqual(3, dataRepository.GetAllGameDetails().Count);

            // AddGameDetails test
            Game game = new Game(4, "Pokerek", Game.GameType.POKER);
            DateTimeOffset date = new DateTimeOffset(DateTime.Now);
            GameDetails gameDetails = new GameDetails(game, date, 300);
            dataRepository.AddGameDetails(gameDetails);
            Assert.AreEqual(4, dataRepository.GetAllGameDetails().Count);

            // GetGameDetails test
            Assert.AreEqual(300, dataRepository.GetGameDetails(game).MinimalBet);

            // UpdateGameDetails test
            GameDetails newGameDetails = new GameDetails(game, date, 400);
            dataRepository.UpdateGameDetails(gameDetails, newGameDetails);
            Assert.AreEqual(400, dataRepository.GetGameDetails(game).MinimalBet);

            // DeleteGameDetails test
            dataRepository.DeleteGameDetails(newGameDetails);
            Assert.AreEqual(3, dataRepository.GetAllGameDetails().Count);
        }
    }
}
