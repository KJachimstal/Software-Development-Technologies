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

        }

        private void EditGameDetails()
        {

        }

        private void RemoveGameDetails()
        {

        }

    }
}
