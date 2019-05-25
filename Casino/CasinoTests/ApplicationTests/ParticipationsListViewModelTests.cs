using System;
using CasinoApplication.Model;
using CasinoApplication.Services;
using CasinoApplication.ViewModel;
using CasinoData;
using CasinoLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CasinoTests.ApplicationTests
{
    [TestClass]
    public class ParticipationsListViewModelTests
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
        public void ParticipationsListRemoveTest()
        {
            Participation participation = Data.DataRepository.GetParticipation(1);
            MainViewModel mainViewModel = new MainViewModel();
            MessagesProvider.RegisterMessageService(new TestMessage());
            mainViewModel.RemoveParticipation(participation);

            // Assertion
            Assert.IsNull(Data.DataRepository.GetParticipation(1));
        }
    }
}
