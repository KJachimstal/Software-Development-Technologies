using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public partial class DataRepository
    {
        public void AddClient(Client client)
        {
            dataContext.Clients.Add(client);
        }

        public Client getClient(int clientNumber)
        {
            return dataContext.Clients.FirstOrDefault(c => c.ClientNumber == clientNumber);
        }

        public IEnumerable<Client> getAllClients()
        {
            return dataContext.Clients;
        }
    }
}
