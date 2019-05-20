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

        [TestMethod]
        public void LargeMultiplier()
        {
            // 50 000x clients, 40 000x games, 30 000x games details, 80 000x participations
            IDataSource dataSource = new RandomDataSource(100);
            dataSource.Fill(dataContext);
        }

        [TestMethod]
        public void BigMultiplier()
        {
            // 500 000x clients, 400 000x games, 300 000x games details, 800 000x participations
            IDataSource dataSource = new RandomDataSource(1000);
            dataSource.Fill(dataContext);
        }

        [TestMethod]
        public void HugeMultiplier()
        {
            // 1 000 000x clients, 800 000x games, 600 000x games details, 1 600 000x participations
            IDataSource dataSource = new RandomDataSource(2000);
            dataSource.Fill(dataContext);
        }
    }
}
