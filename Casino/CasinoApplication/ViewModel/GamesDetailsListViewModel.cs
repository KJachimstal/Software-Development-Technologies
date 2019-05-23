﻿using CasinoLibrary;
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


    }
}
