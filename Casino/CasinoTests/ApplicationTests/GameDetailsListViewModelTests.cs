using System;
using CasinoApplication.Model;
using CasinoApplication.Services;
using CasinoApplication.ViewModel;
using CasinoData;
using CasinoLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CasinoTests.ApplicationTests
{
    [TestClass]
    public class GameDetailsListViewModelTests
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
        public void ClientsListRemoveTest()
        {
            GameDetails gameDetails = Data.DataRepository.GetGameDetails(1);
            MainViewModel mainViewModel = new MainViewModel();
            MessagesProvider.RegisterMessageService(new TestMessage());
            mainViewModel.RemoveGameDetails(gameDetails);

            // Assertion
            Assert.IsNull(Data.DataRepository.GetGameDetails(1));
        }
    }
}
