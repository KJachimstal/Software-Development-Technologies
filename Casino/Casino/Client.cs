using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoLibrary
{
    public class Client
    {
        private int clientNumber;

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

        public Client(int clientNumber, string firstName, string lastName)
        {
            this.clientNumber = clientNumber;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
