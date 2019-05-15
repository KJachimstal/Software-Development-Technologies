using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasinoLibrary;
using CasinoData;
using System.Collections.ObjectModel;
using CasinoSources;

namespace CasinoTests
{
    [TestClass]
    public class DataRepositoryTest
    {

        public static ConstantSource constantSource = new ConstantSource();
        public static DataRepository dataRepository = new DataRepository(constantSource);
        public static DataContext dataContext = new DataContext();
        
        [TestInitialize]
        public void TestInitialize()
        {
            dataRepository.DataContext = dataContext;
            dataRepository.Fill();
        }

        [TestMethod]
        public void ClientTest()
        {
            //GetAllClient test
            Assert.AreEqual(10, dataRepository.GetAllClients().Count);

            //AddClient test
            Client client = new Client(11, "Anna", "Hanna");
            dataRepository.AddClient(client);

            Assert.AreEqual(11, dataRepository.GetAllClients().Count);

            //GetClient test
            Assert.AreEqual(11, dataRepository.GetClient(11).ClientNumber);

            //UpdateClient test
            Client newClient = new Client(11, "Józek", "Daniel");
            dataRepository.UpdateClient(client, newClient);
            Assert.AreEqual("Józek", dataRepository.GetClient(11).FirstName);

            //DeleteClient test 
            dataRepository.DeleteClient(newClient);
            Assert.IsNull(dataRepository.GetClient(11));
        }
    }
}
