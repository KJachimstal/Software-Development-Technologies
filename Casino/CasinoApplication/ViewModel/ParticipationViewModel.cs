using CasinoApplication.Model;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApplication.ViewModel
{
    class ParticipationViewModel
    {
        private ObservableCollection<GameDetails> gameDetailsList;

        public ObservableCollection<GameDetails> GameDetailsList {
            get {
                gameDetailsList = Data.DataRepository.GetAllGameDetails();
                return gameDetailsList;
            }

        }

        private ObservableCollection<Client> clients;

        public ObservableCollection<Client> Clients {
            get {
                clients = Data.DataRepository.GetAllClients();
                return clients;
            }
        }

        private Participation participation;

        private double bet;

        public double Bet {
            get {return bet; }
            set { bet = value; }
        }

        private Client client;

        public Client Client {
            get { return client; }
            set { client = value; }
        }

        private GameDetails gameDetails;

        public GameDetails GameDetails {
            get { return gameDetails; }
            set { gameDetails = value; }
        }

        public ParticipationViewModel(Client client, GameDetails gameDetails, Participation participation)
        {
            this.participation = participation;
            this.gameDetails = GameDetails;
            this.client = Client;
            this.bet = participation.Bet;
        }

        public ParticipationViewModel() { }
    }   
}
