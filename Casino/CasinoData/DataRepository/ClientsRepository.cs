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
        }

        public Client GetClient(int id)
        {
            return dataContext.Clients.FirstOrDefault(c => c.Id == id);
        }

        public ObservableCollection<Client> GetAllClients()
        {
            List<Client> clients = dataContext.Clients.ToList();
            ObservableCollection<Client> collection = new ObservableCollection<Client>();
            foreach (Client client in clients) {
                collection.Add(client);
            }
            return collection;
        }

        public void UpdateClient(Client oldClient, Client newClient)
        {
            oldClient.FirstName = newClient.FirstName;
            oldClient.LastName = newClient.LastName;
        }

        public bool DeleteClient(Client client)
        {
            dataContext.Clients.Remove(client);
            return true;
        }
    }
}
