using System;
using CasinoData;
using CasionSources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CasinoTests
{
    [TestClass]
    public class RandomDataSourceTests
    {
        private DataContext dataContext;

        [TestInitialize]
        public void TestInitialize()
        {
            dataContext = new DataContext();
        }

        [TestMethod]
        public void DefaultMultiplier()
        {
            // 500x clients, 400x games, 300x games details, 800x participations
            IDataSource dataSource = new RandomDataSource();
            dataSource.Fill(dataContext);
        }
    }
}
