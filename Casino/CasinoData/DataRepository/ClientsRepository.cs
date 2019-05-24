using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            dataContext.SaveChanges();
        }

        public Client GetClient(int id)
        {
            return dataContext.Clients.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Client> GetAllClients()
        {
            return dataContext.Clients;
        }

        public void UpdateClient(Client oldClient, Client newClient)
        {
            oldClient.FirstName = newClient.FirstName;
            oldClient.LastName = newClient.LastName;
            dataContext.SaveChanges();
        }

        public bool DeleteClient(Client client)
        {
            dataContext.Clients.Remove(client);
            dataContext.SaveChanges();
            return true;
        }
    }
}
