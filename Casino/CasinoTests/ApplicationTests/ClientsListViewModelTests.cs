using System;
using CasinoApplication.Model;
using CasinoData;
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
        public void ClientsListAddTest()
        {
        }

        [TestMethod]
        public void ClientsListUpdateTest()
        {
        }

        [TestMethod]
        public void ClientsListRemoveTest()
        {
        }
    }
}
