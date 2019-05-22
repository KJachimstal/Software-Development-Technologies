using CasinoApplication.Common;
using CasinoApplication.ViewModel.Commands;
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

        private ICommand cancelCommand;

        public ICommand CancelCommand 
        {
            get 
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new DefaultCommand(e => { MessageBox.Show("Cancel"); }, null);
                }
                return cancelCommand;
            }
        }


    }
}
