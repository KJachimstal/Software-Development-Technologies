using CasinoApplication.ViewModel.Commands;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CasinoApplication.ViewModel
{
    class GameDetailsViewModel : ViewModel
    {
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

        private string startTime;

        public string StartTime {
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
            this.game = game;
            this.id = gameDetails.Id;
            this.startTime = gameDetails.StartTime;
            this.minimalBet = gameDetails.MinimalBet;
        }

        public GameDetailsViewModel() { }

        private ICommand cancelCommand;

        public ICommand CancelCommand {
            get {
                if (cancelCommand == null)
                {
                    cancelCommand = new DefaultCommand(e => OnCancel(), null);
                }
                return cancelCommand; }
        }

        private ICommand saveCommand;

        public ICommand SaveCommand {
            get { return saveCommand; }
            set { saveCommand = value; }
        }


        private Action<object> closeDelegate;
        
        public void SetCloseAction(Action<object> closeDelegate)
        {
            this.closeDelegate = closeDelegate;
        }

        public void OnSave()
        {

        }

        public void OnCancel()
        {

        }

    }
}
