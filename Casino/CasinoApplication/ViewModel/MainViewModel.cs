using CasinoApplication.Interfaces;
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
            DataContext dataContext = new DataContext();
            XMLDataSource dataSource = new XMLDataSource();

            DataRepository dataRepository = new DataRepository(dataSource);
            dataRepository.DataContext = dataContext;
            dataRepository.Fill();

            ClientsList = dataRepository.GetAllClients();

            ServiceProvider.RegisterServiceLocator(new UnityServiceLocator());
            ServiceProvider.Instance.Register<IModalDialog, ClientViewDialog>();
        }
    }
}
