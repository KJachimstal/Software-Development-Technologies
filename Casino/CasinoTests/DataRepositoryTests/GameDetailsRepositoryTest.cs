using System;
using CasinoData;
using CasinoLibrary;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CasinoTests.DataRepositoryTests
{
    [TestClass]
    public class GameDetailsRepositoryTest
    {
        DataRepository dataRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            IDbContext dbContext = new TestContext();
            dataRepository = new DataRepository(dbContext);
        }

        [TestMethod]
        public void GameDetailsAddTest()
        {
            Game game = new Game(3, "Russian", Game.GameType.ROULETTE);
            DateTime localTime1 = new DateTime(2019, 05, 24, 12, 30, 15);
            DateTimeOffset dateTimeOffset1 = new DateTimeOffset(localTime1, TimeZoneInfo.Local.GetUtcOffset(localTime1));
            GameDetails gameDetails = new GameDetails(game, localTime1, 100);
            dataRepository.AddGameDetails(gameDetails);


            // Assertion
            Assert.AreEqual(gameDetails, dataRepository.GetGameDetails(3));
        }

        [TestMethod]
        public void GameDetailsDeleteTest()
        {

            GameDetails gameDetails1 = dataRepository.GetGameDetails(2);
            dataRepository.DeleteGameDetails(gameDetails1);


            // Assertion
            Assert.IsNull(dataRepository.GetGameDetails(2));
        }

        [TestMethod]
        public void GameDetailsGetTest()
        {
            // Assertion
            Assert.AreEqual(1, dataRepository.GetGameDetails(1).Id);
        }

        [TestMethod]
        public void GameDetailsUpdateTest()
        {
            GameDetails oldGameDetails = dataRepository.GetGameDetails(1);

            Game game = new Game(3, "Russian", Game.GameType.ROULETTE);
            DateTime localTime1 = new DateTime(2019, 05, 24, 12, 30, 15);
            DateTimeOffset dateTimeOffset1 = new DateTimeOffset(localTime1, TimeZoneInfo.Local.GetUtcOffset(localTime1));
            GameDetails gameDetails = new GameDetails(game, localTime1, 100);
            dataRepository.UpdateGameDetails(oldGameDetails, gameDetails);

            // Assertion
            Assert.AreEqual(gameDetails, dataRepository.GetGameDetails(1));
        }

        [TestMethod]
        public void GetAllGameDetailsTest()
        {
            // Assertion
            Assert.AreEqual(2, dataRepository.GetAllGameDetails().Count());
        }

    }
}
