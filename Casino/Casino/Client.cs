using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CasinoLibrary
{
    [Serializable()]
    public class Client
    {
        private int clientNumber;

        [XmlElement("ClientNumber")]
        public int ClientNumber {
            get { return clientNumber; }
            set { clientNumber = value; }
        }


        private string firstName;

        [XmlElement("FirstName")]
        public string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        [XmlElement("LastName")]
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

        public Client() { }

        public override bool Equals(object obj)
        {
            var state = obj as Client;
            return state != null &&
                clientNumber == state.ClientNumber &&
                firstName == state.FirstName &&
                lastName == state.LastName;
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
