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
using System.Windows.Input;
using CasinoApplication.Common;
using System.Windows;

namespace CasinoApplication.ViewModel
{
    class GameDetailsViewModel : ViewModel, IDataErrorInfo
    {
        private List<Game> games;

        public List<Game> Games {
            get {
                games = Data.DataRepository.GetAllGames().ToList();
                return games;
            }

        }

        private GameDetails gameDetails;

        private int id;

        public int Id {
            get { return id; }
            set { id = value; }
        }

        private Game game;

        public Game Game {
            get { return game; }
            set { game = value; }
        }

        private DateTime startTime = DateTime.Now;

        public DateTime StartTime {
            get { return startTime; }
            set { startTime = value; }
        }

        private double minimalBet;

        public double MinimalBet {
            get { return minimalBet; }
            set { minimalBet = value; }
        }
            
        public GameDetailsViewModel(Game game, GameDetails gameDetails)
        {
            this.gameDetails = gameDetails;
            Game = game;
            Id = gameDetails.Id;
            StartTime = DateTime.Parse(gameDetails.StartTime);
            MinimalBet = gameDetails.MinimalBet;
        }

        public GameDetailsViewModel() { }

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
                return cancelCommand; }
        }

        private Action<object> closeDelegate;
        
        public void SetCloseAction(Action<object> closeDelegate)
        {
            this.closeDelegate = closeDelegate;
        }

        private Action<object> addDelegate;

        public void SetAddAction(Action<object> addDelegate)
        {
            this.addDelegate = addDelegate;
        }

        public void OnSave()
        {
            DataRepository dataRepository = Data.DataRepository;

            if (Mode == Mode.ADD)
            {
                GameDetails gameDetails = new GameDetails()
                {
                    Game = Game,
                    MinimalBet = MinimalBet,
                    StartTime = StartTime.ToString("o"),
                };
                
                Task.Run(() =>
                {
                    dataRepository.AddGameDetails(gameDetails);
                });

                addDelegate(gameDetails);
            }
            else
            {
                GameDetails gameDetailsModified = new GameDetails()
                {
                    Id = Id,
                    Game = Game,
                    MinimalBet = MinimalBet,
                    StartTime = StartTime.ToString("o"),
                };

                Task.Run(() =>
                {
                    dataRepository.UpdateGameDetails(gameDetails, gameDetailsModified);
                });
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
                if (columnName == "Game")
                {
                    if (Game == null)
                    {
                        return "Please select Game";
                    }
                }
                else if (columnName == "StartTime")
                {
                    if (StartTime == null)
                    {
                        return "Please choose start time";
                    }
                }
                else if (columnName == "MinimalBet")
                {
                    if (MinimalBet == 0)
                    {
                        return "Please enter minimal bet";
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
