using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public partial class DataRepository
    {
        private DbContext dataContext;

        public DbContext DataContext {
            set => dataContext = value; 
        }

        public DataRepository()
        {
            dataContext = new DbContext();
        }
    }
}
