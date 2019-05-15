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

        public Client GetClient(int clientNumber)
        {
            return dataContext.Clients.FirstOrDefault(c => c.ClientNumber == clientNumber);
        }

        public IEnumerable<Client> GetAllClients()
        {
            return dataContext.Clients;
        }

        public void UpdateClient(Client oldClient, Client newClient)
        {
            oldClient.ClientNumber = newClient.ClientNumber;
            oldClient.FirstName = newClient.FirstName;
            oldClient.LastName = newClient.LastName;
        }

        public void DeleteClient(Client client)
        {
            dataContext.Clients.Remove(client);
        }
    }
}
