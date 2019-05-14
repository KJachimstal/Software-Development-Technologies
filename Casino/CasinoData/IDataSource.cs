using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public interface IDataSource
    {
        void Fill(DataContext dataContext);
    }
}
