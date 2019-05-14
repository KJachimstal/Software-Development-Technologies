using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public class DataRepository
    {
        private DataContext dataContext;

        public DataContext DataContext {
            set => dataContext = value; 
        }

        public DataRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        private IDataSource dataSource;

        public IDataSource DataSource {
            get { return dataSource; }
            set { dataSource = value; }
        }

        public DataRepository(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
    }
}
