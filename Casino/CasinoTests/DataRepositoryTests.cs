using System;
using CasinoApplication.Model;
using CasinoData;
using CasinoLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CasinoTests
{
    [TestClass]
    public class DataRepositoryTests
    {
        DataRepository dataRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            IDbContext dbContext = new TestContext();
            dataRepository = new DataRepository(dbContext);
        }

        [TestMethod]
        public void ClientAddTest()
        {
            Client client = new Client(1, "William", "Noel");
            dataRepository.AddClient(client);

            
        }
    }
}
