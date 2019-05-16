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

        [TestMethod]
        public void Fill()
        {
            DataContext dataContext = new DataContext();
            XMLDataSource xmlSource = new XMLDataSource();

            xmlSource.Fill(dataContext);

            //Assertions
            Assert.AreEqual(10, dataContext.Clients.Count);
            Assert.AreEqual(3, dataContext.Games.Count);
            Assert.AreEqual(3, dataContext.GameDetails.Count);
            Assert.AreEqual(3, dataContext.Participations.Count);
        }
    }
}
