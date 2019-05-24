using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CasinoLibrary
{
    [Serializable()]
    public class Client : INotifyPropertyChanged
    {
        private int id;

        public int Id {
            get { return id; }
            set { id = value; }
        }


        private string firstName;

        [XmlElement("FirstName")]
        public string FirstName {
            get { return firstName; }
            set 
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastName;

        [XmlElement("LastName")]
        public string LastName {
            get { return lastName; }
            set 
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public Client(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Client() { }

        public override bool Equals(object obj)
        {
            var state = obj as Client;
            return state != null &&
                id == state.id &&
                firstName == state.FirstName &&
                lastName == state.LastName;
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
