using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    class DataRepository
    {
        private DataContext dataContext;

        public DataContext DataContext {
            get { return dataContext; }
            set { dataContext = value; }
        }

    }
}
