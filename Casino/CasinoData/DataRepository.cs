using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public partial class DataRepository
    {
        private DataContext dataContext;
        private IDataSource dataSource;

        public DataContext DataContext {
            set => dataContext = value; 
        }

        public IDataSource DataSource {
            get { return dataSource; }
            set { dataSource = value; }
        }

        public DataRepository(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public void Fill()
        {
            dataSource.Fill(dataContext);
        }
    }
}
