using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CasionSources
{
    [XmlRoot("ClientsList")]
    public class ClientsList
    {
        public ClientsList()
        {
            Clients = new ObservableCollection<Client>();
        }

        [XmlElement("Client")]
        public ObservableCollection<Client> Clients { get; set; }
    }
}
