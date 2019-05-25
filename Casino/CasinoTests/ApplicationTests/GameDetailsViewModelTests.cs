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
    public class GameDetailsViewModelTests
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
        public void GameDetailsAddViewModelTest()
        {
            Game game = new Game(3, "Russian", Game.GameType.ROULETTE);
            GameDetails gameDetails = new GameDetails();
            GameDetailsViewModel gameDetailsViewModel = new GameDetailsViewModel(game, gameDetails);
            gameDetailsViewModel.Mode = CasinoApplication.Common.Mode.ADD;

            gameDetailsViewModel.SetAddAction(e => { });
            gameDetailsViewModel.SetCloseAction(e => { });
            gameDetailsViewModel.OnSave();

            // Assertion
            Assert.AreEqual(3, Data.DataRepository.GetAllGameDetails().Count());

        }

        [TestMethod]
        public void GameDetailsUpdateViewModelTest()
        {
            Game game = new Game(3, "Crazy Russian", Game.GameType.ROULETTE);
            GameDetails gameDetails = Data.DataRepository.GetGameDetails(1);
            GameDetailsViewModel gameDetailsViewModel = new GameDetailsViewModel(game, gameDetails);
            gameDetailsViewModel.Mode = CasinoApplication.Common.Mode.EDIT;

            gameDetailsViewModel.SetAddAction(e => { });
            gameDetailsViewModel.SetCloseAction(e => { });
            gameDetailsViewModel.OnSave();

            // Assertion
            Assert.AreEqual("Crazy Russian", Data.DataRepository.GetGameDetails(1).Game.Name);

        }
    }
}
