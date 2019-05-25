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
    public class ClientViewModelTests
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
        public void ClientAddViewModelTest()
        {
            Client client = new Client(4, "Wilhelm", "Pa");
            ClientViewModel clientViewModel = new ClientViewModel(client);
            clientViewModel.Mode = CasinoApplication.Common.Mode.ADD;

            clientViewModel.SetAddAction(e => { });
            clientViewModel.SetCloseAction(e => { });
            clientViewModel.OnSave();

            // Assertion
            Assert.AreEqual(3, Data.DataRepository.GetAllClients().Count());

        }
    }
}
