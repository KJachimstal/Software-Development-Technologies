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

        [TestMethod]
        public void ValidGames()
        {
            Game game = dataContext.Games[1];
            Assert.AreEqual(1, game.Id);
            Assert.AreEqual("Texas Holdem", game.Name);
            Assert.AreEqual(Game.GameType.POKER, game.Type);
        }

        [TestMethod]
        public void ValidGamesDetails()
        {
            GameDetails gameDetails = dataContext.GameDetails[0];
            Assert.AreEqual(1, gameDetails.GameId);
            Assert.AreEqual(1, gameDetails.Id);
            Assert.AreEqual(10.5, gameDetails.MinimalBet, 0.00001);
            DateTimeOffset datetime = DateTimeOffset.Parse("2011-11-11T15:05:46.4733406+01:00");
            Assert.AreEqual(datetime, gameDetails.startTime);
        }
    }
}
