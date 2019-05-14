using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoLibrary;

namespace CasinoData
{
    class DataContext
    {
        private List<Client> clients;

        public List<Client> Clients {
            get { return clients; }
            set { clients = value; }
        }

    }
}
