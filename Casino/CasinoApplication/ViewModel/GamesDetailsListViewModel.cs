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
            get => gamesDetails; 
            set {
                gamesDetails = value;
                OnPropertyChanged("GamesDetailsList");
            }
        }

        private GameDetails selectedGameDetails;

        public GameDetails SelectedGameDetails {
            get { return selectedGameDetails; }
            set {
                selectedGameDetails = value;
                EditGameDetailsCommand.RaiseCanExecuteChanged();
                RemoveGameDetailsCommand.RaiseCanExecuteChanged();
            }
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
                    editGameDetailsCommand = new EditCommand(e => EditGameDetails(SelectedGameDetails), e => SelectedGameDetails != null);
                }
                return editGameDetailsCommand; }
        }

        private RemoveCommand removeGameDetailsCommand;

        public RemoveCommand RemoveGameDetailsCommand {
            get {
                if (removeGameDetailsCommand == null)
                {
                    removeGameDetailsCommand = new RemoveCommand(e => RemoveGameDetails(SelectedGameDetails), e => SelectedGameDetails != null);
                }
                return removeGameDetailsCommand; } 
        }

        //------------------- Action
        public void AddGameDetails()
        {
            GameDetailsViewModel viewModel = new GameDetailsViewModel();
            viewModel.Mode = Common.Mode.ADD;

            IModalDialog dialog = GameDetailsProvider.Instance.Get<IModalDialog>();
            viewModel.SetCloseAction(e => dialog.Close());
            viewModel.SetAddAction(e => GamesDetailsList.Add((GameDetails)e));
            dialog.BindViewModel(viewModel);
            dialog.ShowDialog();
        }

        public void EditGameDetails(GameDetails gameDetails)
        {
            GameDetailsViewModel viewModel = new GameDetailsViewModel(gameDetails.Game, gameDetails);
            viewModel.Mode = Common.Mode.EDIT;

            IModalDialog dialog = GameDetailsProvider.Instance.Get<IModalDialog>();
            viewModel.SetCloseAction(e => dialog.Close());
            dialog.BindViewModel(viewModel);
            dialog.ShowDialog();
        }

        public void RemoveGameDetails(GameDetails gameDetails)
        {
            IMessage messageService = MessagesProvider.GetService();
            MessageBoxResult result = messageService.Show("Do You want to delete?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            string message = gameDetails.ToString();
            if (result == MessageBoxResult.Cancel)
            {
                return;
            }
            DataRepository dataRepository = Data.DataRepository;

            bool state = false;
            Task.Run(() =>
            {
                state = dataRepository.DeleteGameDetails(gameDetails);
            });
            
            if (state)
            {
                messageService.Show(string.Format("Game details {0} successfully removed.", message), "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                GamesDetailsList.Remove(gameDetails);
            }
            else
            {
                messageService.Show(string.Format("Couldn't remove game details {0}.", message), "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
