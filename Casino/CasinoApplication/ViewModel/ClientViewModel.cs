using CasinoApplication.Common;
using CasinoApplication.Model;
using CasinoApplication.ViewModel.Commands;
using CasinoData;
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
    class ClientViewModel : ViewModel
    {
        private int clientNumber = 0;

        public int ClientNumber {
            get { return clientNumber; }
            set { clientNumber = value; }
        }

        private string firstName;

        public string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName {
            get { return lastName; }
            set { lastName = value; }
        }

        public ClientViewModel(Client client)
        {
            ClientNumber = client.ClientNumber;
            FirstName = client.FirstName;
            LastName = client.LastName;
        }

        public ClientViewModel() { }

        private ICommand saveCommand;

        public ICommand SaveCommand {
            get {
                if (saveCommand == null)
                {
                    saveCommand = new DefaultCommand(e => OnSave(), null);
                }
                return saveCommand;
            }
        }
            
        private ICommand cancelCommand;

        public ICommand CancelCommand 
        {
            get 
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new DefaultCommand(e => OnCancel(), null);
                }
                return cancelCommand;
            }
        }

        private Action<object> closeDelegate;

        public void SetCloseAction(Action<object> closeDelegate)
        {
            this.closeDelegate = closeDelegate;
        }

        public void OnSave()
        {
            DataRepository dataRepository = Data.DataRepository;
            Client client = new Client()
            {
                FirstName = FirstName,
                LastName = LastName,
            };
            dataRepository.AddClient(client);
            closeDelegate(this);
        }

        private void OnCancel()
        {
            closeDelegate(this);
        }
    }
}
