using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CasinoApplication.ViewModel
{
    class MainViewModel : ViewModel
    {

        private Client selectedClient;

        public Client SelectedClient {
            get { return selectedClient; }
            set { selectedClient = value; }
        }

        private List<Client> clients;

        public List<Client> ClientsList {
            get => clients;
            set {
                clients = value;
                OnPropertyChanged("ClientsCollection");
            }
        }

        public MainViewModel()
        {
            List<Client> clients = new List<Client>();
            clients.Add(new Client(0, "Example", "Example"));
            ClientsList = clients;
        }
    }
}
