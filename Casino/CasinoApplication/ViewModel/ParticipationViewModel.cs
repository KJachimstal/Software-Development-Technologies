using CasinoApplication.Common;
using CasinoApplication.Model;
using CasinoApplication.ViewModel.Commands;
using CasinoData;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        private ICommand saveCommand;

        public ICommand SaveCommand {
            get {
                if (saveCommand == null)
                {
                    saveCommand = new DefaultCommand(e => OnSave(), null);
                }
                return saveCommand;
            }
        }

        private ICommand cancelCommand;

        public ICommand CancelCommand {
            get {
                if (cancelCommand == null)
                {
                    cancelCommand = new DefaultCommand(e => OnCancel(), null);
                }
                return cancelCommand;
            }
        }

        private Action<object> closeDelegate;

        public void SetCloseAction(Action<object> closeDelegate)
        {
            this.closeDelegate = closeDelegate;
        }

        public void OnSave()
        {
            //    DataRepository dataRepository = Data.DataRepository;

            //    if (Mode == Mode.ADD)
            //    {
            //        Participation participation = new Participation()
            //        {
            //            Client = Client,
            //            GameDetails = GameDetails,
            //            Bet = Bet,                    
            //        };
            //        dataRepository.AddGameDetails(gameDetails);
            //    }
            //    else
            //    {
            //        Participation participationModified = new Participation()
            //        {

            //        };
            //        dataRepository.UpdateParticipation(participation, participationModified);
            //    }

            //    closeDelegate(this);
        }

        private void OnCancel()
        {
            closeDelegate(this);
        }


    }   
}
