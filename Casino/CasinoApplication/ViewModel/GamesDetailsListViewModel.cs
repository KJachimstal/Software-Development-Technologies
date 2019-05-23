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
        private ObservableCollection<GameDetails> gamesDetails;

        public ObservableCollection<GameDetails> GamesDetailsList {
            get { return gamesDetails; }
            set { gamesDetails = value; }
        }

        private GameDetails gameDetails;

        public GameDetails SelectedGameDetails {
            get { return gameDetails; }
            set { gameDetails = value; }
        }

        // ---------------------------- Commands
        private AddCommand addGameDetailsCommand;

        public AddCommand AddGameDetailsCommand {
            get {
                if (addGameDetailsCommand == null)
                {
                    addGameDetailsCommand = new AddCommand(e => AddGameDetails());
                }
                return addGameDetailsCommand; }
        }

        private EditCommand editGameDetailsCommand;

        public EditCommand EditGameDetailsCommand {
            get {
                if (editGameDetailsCommand == null)
                {
                    editGameDetailsCommand = new EditCommand(e => EditGameDetails(), e => SelectedGameDetails != null);
                }
                return editGameDetailsCommand; }
        }

        private RemoveCommand removeGameDetailsCommand;

        public RemoveCommand RemoveGameDetailsCommand {
            get {
                if (removeGameDetailsCommand == null)
                {
                    removeGameDetailsCommand = new RemoveCommand(e => RemoveGameDetails(), e => SelectedGameDetails != null);
                }
                return removeGameDetailsCommand; } 
        }

        //------------------- Action
        private void AddGameDetails()
        {
            GameDetailsViewModel viewModel = new GameDetailsViewModel();
            viewModel.Mode = Common.Mode.ADD;

            IModalDialog dialog = GameDetailsProvider.Instance.Get<IModalDialog>();
            viewModel.SetCloseAction(e => dialog.Close());
            dialog.BindViewModel(viewModel);
            dialog.ShowDialog();
        }

        private void EditGameDetails()
        {
            GameDetailsViewModel viewModel = new GameDetailsViewModel(game, gameDetails);
            viewModel.Mode = Common.Mode.EDIT;

            IModalDialog dialog = GameDetailsProvider.Instance.Get<IModalDialog>();
            viewModel.SetCloseAction(e => dialog.Close());
            dialog.BindViewModel(viewModel);
            dialog.ShowDialog();
        }

        private void RemoveGameDetails()
        {
            MessageBoxResult result = MessageBox.Show("Do You want to delete?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (result == MessageBoxResult.Cancel)
            {
                return;
            }
            DataRepository dataRepository = Data.DataRepository;
            if (dataRepository.DeleteGameDetails(gameDetails))
            {
                MessageBox.Show(string.Format("Game details {0} successfully removed.", gameDetails), "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(string.Format("Couldn't remove game details {0}.", gameDetails), "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
