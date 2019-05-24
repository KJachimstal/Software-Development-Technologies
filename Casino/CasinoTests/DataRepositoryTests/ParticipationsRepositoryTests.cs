using System;
using System.Linq;
using CasinoData;
using CasinoLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CasinoTests.DataRepositoryTests
{
    [TestClass]
    public class ParticipationsRepositoryTests
    {
        DataRepository dataRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            IDbContext dbContext = new TestContext();
            dataRepository = new DataRepository(dbContext);
        }

        [TestMethod]
        public void ParticipationAddTest()
        {
            Client client = new Client(1, "One", "One");
            Game game = new Game(1, "GameOne", Game.GameType.BRIDGE);
            DateTime localTime = new DateTime(2019, 05, 24, 12, 30, 15);
            DateTimeOffset dateTimeOffset = new DateTimeOffset(localTime, TimeZoneInfo.Local.GetUtcOffset(localTime));
            GameDetails gameDetails = new GameDetails(game, dateTimeOffset, 100);
            Participation participation = new Participation(client, gameDetails, 110);

            dataRepository.AddParticipation(participation);

            // Assertion
            Assert.AreEqual(participation, dataRepository.GetParticipation(3));
        }

        [TestMethod]
        public void ParticipationDeleteTest()
        {
            dataRepository.DeleteParticipation(dataRepository.GetParticipation(1));

            // Assertion
            Assert.AreEqual(1, dataRepository.GetAllParticipations().Count());
        }

        [TestMethod]
        public void ParticipationGetTest()
        {
        }

        [TestMethod]
        public void ParticipationUpdateTest()
        {
        }

        [TestMethod]
        public void GetAllParticipationsTest()
        {
        }
    }
}
