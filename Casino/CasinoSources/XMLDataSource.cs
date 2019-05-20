using CasinoData;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            FillGamesDetails();
            FillParticipations();
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

        private void FillGamesDetails()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(GamesDetailsList));
            TextReader reader = new StreamReader(@"Data\GamesDetails.xml");
            object obj = deserializer.Deserialize(reader);
            GamesDetailsList gamesDetails = (GamesDetailsList)obj;

            dataContext.GameDetails = new ObservableCollection<GameDetails>();
            foreach (GameDetails gameDetails in gamesDetails.GamesDetails)
            {
                Game game = dataContext.Games[gameDetails.GameId];
                gameDetails.Game = game;
                dataContext.GameDetails.Add(gameDetails);
            }
        }

        private void FillParticipations()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ParticipationsList));
            TextReader reader = new StreamReader(@"Data\Participations.xml");
            object obj = deserializer.Deserialize(reader);
            ParticipationsList participations = (ParticipationsList)obj;

            dataContext.Participations = new List<Participation>();
            foreach (Participation participation in participations.Participations)
            {
                Client client = dataContext.Clients.FirstOrDefault(e => e.ClientNumber == participation.ClientId);
                participation.Client = client;
                GameDetails gameDetails = dataContext.GameDetails.FirstOrDefault(e => e.Id == participation.GameDetailsId);
                participation.GameDetails = gameDetails;
                dataContext.Participations.Add(participation);
            }
        }
    }
}
