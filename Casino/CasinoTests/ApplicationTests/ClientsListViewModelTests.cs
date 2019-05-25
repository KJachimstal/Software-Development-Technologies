using System;
using System.Linq;
using CasinoApplication.Model;
using CasinoApplication.Services;
using CasinoApplication.ViewModel;
using CasinoApplication.ViewModel.Commands;
using CasinoData;
using CasinoLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CasinoTests.ApplicationTests
{
    [TestClass]
    public class ClientsListViewModelTests
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
            Client client = Data.DataRepository.GetClient(1);
            MainViewModel mainViewModel = new MainViewModel();
            MessagesProvider.RegisterMessageService(new TestMessage());
            mainViewModel.RemoveClient(client);
            


            // Assertion
            Assert.IsNull(Data.DataRepository.GetClient(1));
        }
    }
}
