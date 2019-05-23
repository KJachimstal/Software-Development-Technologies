using CasinoApplication.Interfaces;
using CasinoApplication.Model;
using CasinoApplication.Services;
using CasinoApplication.ViewModel.Commands;
using CasinoData;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            GameViewModel viewModel = new GameViewModel();
            viewModel.Mode = Common.Mode.ADD;

            IModalDialog dialog = GameProvider.Instance.Get<IModalDialog>();
            viewModel.SetCloseAction(e => dialog.Close());
            dialog.BindViewModel(viewModel);
            dialog.ShowDialog();
        }

        private void EditGame(Game game)
        {
            GameViewModel viewModel = new GameViewModel(game);
            viewModel.Mode = Common.Mode.EDIT;

            IModalDialog dialog = GameProvider.Instance.Get<IModalDialog>();
            viewModel.SetCloseAction(e => dialog.Close());
            dialog.BindViewModel(viewModel);
            dialog.ShowDialog();
        }

        private void RemoveGame(Game game)
        {
            MessageBoxResult result = MessageBox.Show("Do You want to delete?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (result == MessageBoxResult.Cancel)
            {
                return;
            }
            DataRepository dataRepository = Data.DataRepository;
            if (dataRepository.DeleteGame(game))
            {
                MessageBox.Show(string.Format("Game {0} successfully removed.", game), "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(string.Format("Couldn't remove game {0}.", game), "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
