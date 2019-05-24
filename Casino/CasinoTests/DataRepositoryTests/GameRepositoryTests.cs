using System;
using CasinoData;
using CasinoLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CasinoTests.DataRepositoryTests
{
    [TestClass]
    public class GameRepositoryTests
    {
        DataRepository dataRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            IDbContext dbContext = new TestContext();
            dataRepository = new DataRepository(dbContext);
        }

        [TestMethod]
        public void GameAddTest()
        {
            Game game = new Game(3, "Russian", Game.GameType.ROULETTE);
            dataRepository.AddGame(game);

            // Assertion
            Assert.AreEqual(game, dataRepository.GetGame(3));
        }

        [TestMethod]
        public void GameDeleteTest()
        {
            dataRepository.DeleteGame(dataRepository.GetGame(2));

            // Assertion
            Assert.IsNull(dataRepository.GetGame(2));
        }

        [TestMethod]
        public void GameGetTest()
        {
            Game game = new Game(2, "GameTwo", Game.GameType.POKER);

            // Assertion
            Assert.AreEqual(game, dataRepository.GetGame(2));
        }
    }
}
