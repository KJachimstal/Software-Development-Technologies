using CasinoApplication.ViewModel.Commands;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CasinoApplication.ViewModel
{
    class MainViewModel : ViewModel
    {

        private Client selectedClient;

        public Client SelectedClient {
            get { return selectedClient; }
            set 
            {
                selectedClient = value;
                RemoveClientCommand.RaiseCanExecuteChanged();
            }
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
            List<Client> clients = new List<Client>
            {
                new Client(0, "Example", "Example")
            };
            ClientsList = clients;
        }

        // ------------------------ Commands
        private RemoveClientCommand removeClientCommand;
        public RemoveClientCommand RemoveClientCommand {
            get {
                if (removeClientCommand == null)
                {
                    removeClientCommand = new RemoveClientCommand(e => OnClientRemove(), e => SelectedClient != null);
                }
                return removeClientCommand;
            }
        }

        // ------------------------ Actions
        public void OnClientRemove()
        {
            MessageBox.Show("Working!");
        }

    }
}
