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
    }
}
