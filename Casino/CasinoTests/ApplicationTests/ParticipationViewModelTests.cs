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
    public class ParticipationViewModelTests
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
        public void ParticipationAddViewModelTest()
        {
            Client client = new Client(4, "Wilhelm", "Pa");
            GameDetails gameDetails = new GameDetails();
            Participation participation = new Participation();
            ParticipationViewModel participationViewModel = new ParticipationViewModel(client, gameDetails, participation);
            participationViewModel.Mode = CasinoApplication.Common.Mode.ADD;

            participationViewModel.SetAddAction(e => { });
            participationViewModel.SetCloseAction(e => { });
            participationViewModel.OnSave();

            // Assertion
            Assert.AreEqual(3, Data.DataRepository.GetAllParticipations().Count());

        }

        [TestMethod]
        public void ParticipationUpdateViewModelTest()
        {
            Client client = Data.DataRepository.GetParticipation(1).Client;
            GameDetails gameDetails = Data.DataRepository.GetParticipation(1).GameDetails;
            Participation participation = Data.DataRepository.GetParticipation(1);
            client.FirstName = "Wilhelm";
            ParticipationViewModel participationViewModel = new ParticipationViewModel(client, gameDetails, participation);
            participationViewModel.Mode = CasinoApplication.Common.Mode.ADD;

            participationViewModel.SetAddAction(e => { });
            participationViewModel.SetCloseAction(e => { });
            participationViewModel.OnSave();

            // Assertion
            Assert.AreEqual("Wilhelm", Data.DataRepository.GetParticipation(1).Client.FirstName);

        }
    }
}
