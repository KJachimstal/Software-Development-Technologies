using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasinoLibrary;
using System.Xml.Serialization;
using System.IO;
using CasinoData;
using CasionSources;

namespace CasinoTests
{
    [TestClass]
    public class XMLDataSourceTests
    {

        private DataContext dataContext;
        private XMLDataSource xmlSource;

        [TestInitialize]
        public void TestInitialize()
        {
            dataContext = new DataContext();
            xmlSource = new XMLDataSource();
            xmlSource.Fill(dataContext);
        }

        [TestMethod]
        public void Fill()
        {
            //Assertions
            Assert.AreEqual(6, dataContext.Clients.Count);
            Assert.AreEqual(3, dataContext.Games.Count);
            Assert.AreEqual(1, dataContext.GameDetails.Count);
            Assert.AreEqual(1, dataContext.Participations.Count);
        }

        [TestMethod]
        public void ValidClients()
        {
            Client client = dataContext.Clients[0];
            Assert.AreEqual(1213, client.ClientNumber);
            Assert.AreEqual("Steve", client.FirstName);
            Assert.AreEqual("Works", client.LastName);
        }
    }
}
