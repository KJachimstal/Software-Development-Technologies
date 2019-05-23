using CasinoApplication.Interfaces;
using CasinoApplication.Model;
using CasinoApplication.Services;
using CasinoApplication.View;
using CasinoApplication.ViewModel.Commands;
using CasinoData;
using CasinoLibrary;
using CasionSources;
using System;
using System.Collections.Generic;
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
            XMLDataSource dataSource = new XMLDataSource();
            Data.RegisterDataRepository(new DataRepository(dataSource));

            DataRepository dataRepository = Data.DataRepository;
            ClientsList = dataRepository.GetAllClients();
            GamesList = dataRepository.GetAllGames();

            ServiceProvider.RegisterServiceLocator(new UnityServiceLocator());
            ServiceProvider.Instance.Register<IModalDialog, ClientViewDialog>();

            GameProvider.RegisterServiceLocator(new UnityServiceLocator());
            GameProvider.Instance.Register<IModalDialog, GameViewDialog>();
        }
    }
}
