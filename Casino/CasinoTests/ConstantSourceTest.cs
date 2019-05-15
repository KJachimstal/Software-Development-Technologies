using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasinoData;
using CasinoSources;

namespace CasinoTests
{
    [TestClass]
    public class ConstantSourceTest
    {
        [TestMethod]
        public void TestConstantSource()
        {
            DataContext dataContext = new DataContext();
            ConstantSource casinoSources = new ConstantSource();

            casinoSources.Fill(dataContext);

            //Assertions
            Assert.AreEqual(10, dataContext.Clients.Count);
            Assert.AreEqual(3, dataContext.Games.Count);
            Assert.AreEqual(3, dataContext.GameDetails.Count);
            Assert.AreEqual(3, dataContext.Participations.Count);

        }
    }
}
