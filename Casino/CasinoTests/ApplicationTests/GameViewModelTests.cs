using System;
using System.Linq;
using CasinoApplication.Model;
using CasinoApplication.ViewModel;
using CasinoData;
using CasinoLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CasinoTests.ApplicationTests
{
    [TestClass]
    public class GameViewModelTests
    {
        DataRepository dataRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            IDbContext dbContext = new TestContext();
            dataRepository = new DataRepository(dbContext);
            Data.RegisterDataRepository(dataRepository);
        }

        [TestMethod]
        public void GameAddViewModelTest()
        {
            Game game = new Game(3, "Russian", Game.GameType.ROULETTE);
            GameViewModel gameViewModel = new GameViewModel(game);
            gameViewModel.Mode = CasinoApplication.Common.Mode.ADD;

            gameViewModel.SetAddAction(e => { });
            gameViewModel.SetCloseAction(e => { });
            gameViewModel.OnSave();

            // Assertion
            Assert.AreEqual(3, Data.DataRepository.GetAllGames().Count());

        }

        [TestMethod]
        public void GameUpdateViewModelTest()
        {
            Game game = Data.DataRepository.GetGame(1);
            game.Name = "ONE";
            GameViewModel gameViewModel = new GameViewModel(game);
            gameViewModel.Mode = CasinoApplication.Common.Mode.EDIT;

            gameViewModel.SetAddAction(e => { });
            gameViewModel.SetCloseAction(e => { });
            gameViewModel.OnSave();

            // Assertion
            Assert.AreEqual("ONE", Data.DataRepository.GetGame(1).Name);

        }
    }
}
