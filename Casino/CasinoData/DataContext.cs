using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoLibrary;

namespace CasinoData
{
    public class DataContext
    {
        private ObservableCollection<Client> clients;

        public ObservableCollection<Client> Clients {
            get { return clients; }
            set { clients = value; }
        }

        private ObservableCollection<Game> games;

        public ObservableCollection<Game> Games {
            get { return games; }
            set { games = value; }
        }

        private ObservableCollection<GameDetails> gameDetails;

        public ObservableCollection<GameDetails> GameDetails {
            get { return gameDetails; }
            set { gameDetails = value; }
        }

        private ObservableCollection<Participation> participations;

        public ObservableCollection<Participation> Participations {
            get { return participations; }
            set { participations = value; }
        }

        public DataContext(ObservableCollection<Client> clients, ObservableCollection<Game> games, ObservableCollection<GameDetails> gameDetails, ObservableCollection<Participation> participations)
        {
            this.clients = clients;
            this.games = games;
            this.gameDetails = gameDetails;
            this.participations = participations;
        }

        public DataContext() { }
    }
}
