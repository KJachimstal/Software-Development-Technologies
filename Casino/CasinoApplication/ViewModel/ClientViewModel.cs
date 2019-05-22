using CasinoApplication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
