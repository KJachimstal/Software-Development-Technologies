using CasinoApplication.Common;
using CasinoApplication.Model;
using CasinoApplication.ViewModel.Commands;
using CasinoData;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CasinoApplication.ViewModel
{
    class ParticipationViewModel : ViewModel, IDataErrorInfo
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
            this.gameDetails = participation.GameDetails;
            this.client = participation.Client;
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
            DataRepository dataRepository = Data.DataRepository;

            if (Mode == Mode.ADD)
            {
                Participation participation = new Participation()
                {
                    Client = Client,
                    GameDetails = GameDetails,
                    Bet = Bet,
                };
                dataRepository.AddParticipation(participation);
            }
            else
            {
                Participation participationModified = new Participation()
                {
                    Client = Client,
                    GameDetails = GameDetails,
                    Bet = Bet,
                };
                dataRepository.UpdateParticipation(participation, participationModified);
            }

            closeDelegate(this);
        }

        private void OnCancel()
        {
            closeDelegate(this);
        }

        #region IDataErrorInfo Members
        string IDataErrorInfo.this[string columnName] {
            get {
                if (columnName == "GameDetails")
                {
                    if (GameDetails == null)
                    {
                        return "Please select GameDetails";
                    }
                }
                else if (columnName == "Client")
                {
                    if (Client == null)
                    {
                        return "Please select Client";
                    }
                }
                else if (columnName == "Bet")
                {
                    if (Bet == 0)
                    {
                        return "Please enter bet";
                    }
                }
                return null;
            }
        }

        string IDataErrorInfo.Error {
            get { return string.Empty; }
        }
        #endregion
    }
}
