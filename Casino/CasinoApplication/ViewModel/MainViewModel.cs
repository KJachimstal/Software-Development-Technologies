using CasinoApplication.Interfaces;
using CasinoApplication.Model;
using CasinoApplication.Services;
using CasinoApplication.View;
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
using System.Windows.Input;

namespace CasinoApplication.ViewModel
{
    public partial class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            Data.RegisterDataRepository(new DataRepository());

            DataRepository dataRepository = Data.DataRepository;


            ClientsList = new ObservableCollection<Client>();
            foreach (Client client in dataRepository.GetAllClients())
            {
                ClientsList.Add(client);
            }

            GamesList = new ObservableCollection<Game>(); 
            foreach (Game game in dataRepository.GetAllGames())
            {
                GamesList.Add(game);
            }

            GamesDetailsList = new ObservableCollection<GameDetails>();
            foreach (GameDetails gameDetails in dataRepository.GetAllGameDetails())
            {
                GamesDetailsList.Add(gameDetails);
            }


            ParticipationsList = new ObservableCollection<Participation>();
            foreach (Participation participation in dataRepository.GetAllParticipations())
            {
                ParticipationsList.Add(participation);
            }

            ClientProvider.RegisterServiceLocator(new UnityServiceLocator());
            ClientProvider.Instance.Register<IModalDialog, ClientViewDialog>();

            GameProvider.RegisterServiceLocator(new UnityServiceLocator());
            GameProvider.Instance.Register<IModalDialog, GameViewDialog>();

            GameDetailsProvider.RegisterServiceLocator(new UnityServiceLocator());
            GameDetailsProvider.Instance.Register<IModalDialog, GameDetailsViewDialog>();

            ParticipationProvider.RegisterServiceLocator(new UnityServiceLocator());
            ParticipationProvider.Instance.Register<IModalDialog, ParticipationViewDialog>();
        }
    }
}
