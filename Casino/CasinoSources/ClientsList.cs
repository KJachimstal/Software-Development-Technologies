using CasinoLibrary;
using System;
using System.Collections.Generic;
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
            Clients = new List<Client>();
        }

        [XmlElement("Client")]
        public List<Client> Clients { get; set; }
    }
}
