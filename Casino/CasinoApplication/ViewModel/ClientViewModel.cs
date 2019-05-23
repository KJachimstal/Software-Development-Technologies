﻿using CasinoApplication.Common;
using CasinoApplication.Model;
using CasinoApplication.ViewModel.Commands;
using CasinoData;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CasinoApplication.ViewModel
{
    class ClientViewModel : ViewModel, IDataErrorInfo
    {
        private Client client;

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
            this.client = client;
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

            if (Mode == Mode.ADD)
            {
                Client client = new Client()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                };
                dataRepository.AddClient(client);
            } 
            else
            {
                Client modified = new Client()
                {
                    ClientNumber = ClientNumber,
                    FirstName = FirstName,
                    LastName = LastName,
                };
                dataRepository.UpdateClient(client, modified);
            }

            closeDelegate(this);
        }

        private void OnCancel()
        {
            closeDelegate(this);
        }

        #region IDataErrorInfo Members
        string IDataErrorInfo.this[string columnName] 
        {
            get 
            {
                if (columnName == "FirstName")
                {
                    if (FirstName == null)
                    {
                        return "Please enter first name";
                    }
                    else if (FirstName.Trim() == string.Empty)
                    {
                        return "First name is required";
                    }
                }
                else if (columnName == "LastName")
                {
                    if (LastName == null)
                    {
                        return "Please enter last name";
                    }
                    else if (LastName.Trim() == string.Empty)
                    {
                        return "Last name is required";
                    }
                }
                return null;
            }
        }

        string IDataErrorInfo.Error 
        {
            get { return string.Empty; }
        }
        #endregion
    }
}
