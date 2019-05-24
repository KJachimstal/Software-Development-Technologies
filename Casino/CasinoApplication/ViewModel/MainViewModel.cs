﻿using CasinoApplication.Interfaces;
using CasinoApplication.Model;
using CasinoApplication.Services;
using CasinoApplication.View;
using CasinoApplication.ViewModel.Commands;
using CasinoData;
using CasinoLibrary;
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
            Data.RegisterDataRepository(new DataRepository());

            DataRepository dataRepository = Data.DataRepository;
            ClientsList = dataRepository.GetAllClients();
            GamesList = dataRepository.GetAllGames();
            GamesDetailsList = dataRepository.GetAllGameDetails();
            ParticipationsList = dataRepository.GetAllParticipations();

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
