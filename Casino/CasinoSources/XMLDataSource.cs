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
        private DataContext dataContext;

        public void Fill(DataContext dataContext)
        {
            this.dataContext = dataContext;
            FillClients();
            FillGames();
        }

        private void FillClients()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ClientsList));
            TextReader reader = new StreamReader(@"Data\Clients.xml");
            object obj = deserializer.Deserialize(reader);
            ClientsList clients = (ClientsList)obj;
            dataContext.Clients = clients.Clients;
        }

        private void FillGames()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(GamesList));
            TextReader reader = new StreamReader(@"Data\Games.xml");
            object obj = deserializer.Deserialize(reader);
            GamesList games = (GamesList)obj;

            Dictionary<int, Game> gamesDictionary = new Dictionary<int, Game>();
            foreach (Game game in games.Games)
            {
                gamesDictionary.Add(game.Id, game);
            }
            dataContext.Games = gamesDictionary;
        }
    }
}
