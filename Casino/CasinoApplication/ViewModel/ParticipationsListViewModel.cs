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
        private ObservableCollection<Participation> participations;

        public ObservableCollection<Participation> ParticipationsList {
            get => participations;
            set {
                participations = value;
                OnPropertyChanged("GamesDetailsList");
            }
        }

        private Participation selectedParticipation;

        public Participation SelectedParticipation {
            get { return selectedParticipation; }
            set {
                selectedParticipation = value;
                EditParticipationCommand.RaiseCanExecuteChanged();
                RemoveParticipationCommand.RaiseCanExecuteChanged();
            }
        }

        // ------------------------ Comands
        private AddCommand addParticipationCommand;

        public AddCommand AddParticipationCommand {
            get {
                if (addParticipationCommand == null)
                {
                    addParticipationCommand = new AddCommand(e => AddParticipation());
                }
                return addParticipationCommand;
            }
        }

        private EditCommand editParticipationCommand;

        public EditCommand EditParticipationCommand {
            get {
                if (editParticipationCommand == null)
                {
                    editParticipationCommand = new EditCommand(e => EditParticipation(SelectedParticipation), e => SelectedParticipation != null);
                }
                return editParticipationCommand;
            }
        }

        private RemoveCommand removeParticipationCommand;

        public RemoveCommand RemoveParticipationCommand {
            get {
                if (removeParticipationCommand == null)
                {
                    removeParticipationCommand = new RemoveCommand(e => RemoveParticipation(SelectedParticipation), e => SelectedParticipation != null);
                }
                return removeParticipationCommand;
            }
        }

        //----------------- Action
        private void AddParticipation()
        {
            ParticipationViewModel viewModel = new ParticipationViewModel();
            viewModel.Mode = Common.Mode.ADD;

            IModalDialog dialog = ParticipationProvider.Instance.Get<IModalDialog>();
            viewModel.SetCloseAction(e => dialog.Close());
            viewModel.SetAddAction(e => ParticipationsList.Add((Participation) e));
            dialog.BindViewModel(viewModel);
            dialog.ShowDialog();
        }

        private void EditParticipation(Participation participation)
        {
            ParticipationViewModel viewModel = new ParticipationViewModel(participation.Client, participation.GameDetails, participation);
            viewModel.Mode = Common.Mode.EDIT;

            IModalDialog dialog = ParticipationProvider.Instance.Get<IModalDialog>();
            viewModel.SetCloseAction(e => dialog.Close());
            dialog.BindViewModel(viewModel);
            dialog.ShowDialog();
        }

        private void RemoveParticipation(Participation participation)
        {
            MessageBoxResult result = MessageBox.Show("Do You want to delete?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (result == MessageBoxResult.Cancel)
            {
                return;
            }
            DataRepository dataRepository = Data.DataRepository;
            if (dataRepository.DeleteParticipation(participation))
            {
                MessageBox.Show(string.Format("Participation {0} successfully removed.", participation), "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ParticipationsList.Remove(participation);
            }
            else
            {
                MessageBox.Show(string.Format("Couldn't remove participation {0}.", participation), "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
