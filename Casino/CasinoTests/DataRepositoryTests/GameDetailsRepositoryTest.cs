using System;
using CasinoData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CasinoTests.DataRepositoryTests
{
    [TestClass]
    public class GameDetailsRepositoryTest
    {
        DataRepository dataRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            IDbContext dbContext = new TestContext();
            dataRepository = new DataRepository(dbContext);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
