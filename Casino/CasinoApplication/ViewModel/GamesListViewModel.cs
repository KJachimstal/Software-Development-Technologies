using CasinoApplication.ViewModel.Commands;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApplication.ViewModel
{
    public partial class MainViewModel : ViewModel
    {
        private Game game;

        public Game SelectedGame {
            get { return game; }
            set 
            {
                game = value;
                EditGameCommand.RaiseCanExecuteChanged();
                RemoveGameCommand.RaiseCanExecuteChanged();
            }
        }

        private ObservableCollection<Game> games;

        public ObservableCollection<Game> GamesList {
            get { return games; }
            set 
            {
                games = value;
                OnPropertyChanged("GamesList");
            }
        }

        // ------------------------ Commands
        private AddCommand addGameCommand;
        public AddCommand AddGameCommand {
            get {
                if (addGameCommand == null)
                {
                    addGameCommand = new AddCommand(e => AddGame());
                }
                return addGameCommand;
            }
        }

        public EditCommand editGameCommand;

        public EditCommand EditGameCommand {
            get {
                if (editGameCommand == null)
                {
                    editGameCommand = new EditCommand(e => EditGame(SelectedGame), e => SelectedGame != null);
                }
                return editGameCommand;
            }
        }

        private RemoveCommand removeGameCommand;
        public RemoveCommand RemoveGameCommand {
            get {
                if (removeGameCommand == null)
                {
                    removeGameCommand = new RemoveCommand(e => RemoveGame(SelectedGame), e => SelectedGame != null);
                }
                return removeGameCommand;
            }
        }


        // ------------------------ Action
        private void AddGame()
        {

        }

        private void EditGame(Game game)
        {

        }

        private void RemoveGame(Game game)
        {

        }
    }
}
