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
        private List<Client> clients;

        public List<Client> Clients {
            get { return clients; }
            set { clients = value; }
        }

        private Dictionary<int, Game> games;

        public Dictionary<int, Game> Games {
            get { return games; }
            set { games = value; }
        }

        private ObservableCollection<GameDetail> gameDetails;

        public ObservableCollection<GameDetail> GameDetails {
            get { return gameDetails; }
            set { gameDetails = value; }
        }

        private List<Participation> participation;

        public List<Participation> Participation {
            get { return participation; }
            set { participation = value; }
        }

        public DataContext(List<Client> clients, Dictionary<int, Game> games, ObservableCollection<GameDetail> gameDetails, List<Participation> participation)
        {
            this.clients = clients;
            this.games = games;
            this.gameDetails = gameDetails;
            this.participation = participation;
        }
    }
}
