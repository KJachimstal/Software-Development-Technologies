using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoLibrary;

namespace CasinoData
{
    public partial class DataService
    {
        public string PrintClients(List<Client> clients)
        {
            string clientsString = "";

            foreach (Client client in clients)
            {
                clientsString += client;
                if (clients.LastIndexOf(client) != clients.Count)
                {
                    clientsString += ", ";
                }
            }

            return clientsString;
        }

        public void AddClient(Client client)
        {
            if (!dataRepository.GetAllClients().Contains(client))
            {
                dataRepository.AddClient(client);
            } else
            {
                throw new Exception("Client alredy exists!");
            }
        }

        public void DeleteClient(Client client)
        {
            if (dataRepository.GetAllClients().Contains(client))
            {
                dataRepository.DeleteClient(client);
            } else
            {
                throw new Exception("Client not found!");
            }
        }

        public void UpdateClient(Client oldClient, Client newClient)
        {
            if (dataRepository.GetAllClients().Contains(oldClient))
            {
                dataRepository.UpdateClient(oldClient, newClient);
            } else
            {
                throw new Exception("Client not found! You can not change.");
            } 
        }
    }
}
