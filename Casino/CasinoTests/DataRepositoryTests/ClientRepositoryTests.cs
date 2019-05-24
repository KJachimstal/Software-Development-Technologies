using System;
using System.Collections;
using System.Linq;
using CasinoData;
using CasinoLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CasinoTests.DataRepositoryTests
{
    [TestClass]
    public class ClientRepositoryTests
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
            Client client = new Client(3, "William", "Noel");
            dataRepository.AddClient(client);

            // Assertion
            Assert.AreEqual(client, dataRepository.GetClient(3));
        }

        [TestMethod]
        public void ClientDeleteTest()
        {
            dataRepository.DeleteClient(dataRepository.GetClient(2));

            // Assertion
            Assert.IsNull(dataRepository.GetClient(2));
        }

        [TestMethod]
        public void ClientGetTest()
        {
            Client client = new Client(3, "William", "Noel");
            dataRepository.AddClient(client);

            // Assertion
            Assert.AreEqual(client, dataRepository.GetClient(3));
        }

        [TestMethod]
        public void ClientUpdateTest()
        {
            Client newClient = new Client(2, "William", "Noel");
            dataRepository.UpdateClient(dataRepository.GetClient(2), newClient);

            // Assertion
            Assert.AreEqual(newClient, dataRepository.GetClient(2));
        }

        [TestMethod]
        public void GetAllClientsTest()
        {
            // Assertion
            Assert.AreEqual(2, dataRepository.GetAllClients().Count());
        }
    }
}
