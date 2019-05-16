using CasinoData;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CasionSources
{
    public class XMLDataSource : IDataSource
    {
        public void Fill(DataContext dataContext)
        {
            FillClients();
        }

        private void FillClients()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Client));
            TextReader reader = new StreamReader(@"Data\Clients.xml");
            object obj = deserializer.Deserialize(reader);
            Client client = (Client)obj;
            Console.WriteLine(client);
        }
    }
}
