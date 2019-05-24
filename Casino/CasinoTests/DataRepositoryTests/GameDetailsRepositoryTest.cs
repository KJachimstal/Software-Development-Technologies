using System;
using CasinoData;
using CasinoLibrary;
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


    }
}
