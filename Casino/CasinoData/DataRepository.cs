using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public partial class DataRepository
    {
        private IDbContext dataContext;

        public IDbContext DataContext {
            set => dataContext = value; 
        }

        public DataRepository(IDbContext dbContext)
        {
            dataContext = dbContext;
        }
    }
}
