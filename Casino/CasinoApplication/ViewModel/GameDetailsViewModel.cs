﻿using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApplication.ViewModel
{
    class GameDetailsViewModel : ViewModel
    {
        private GameDetails gameDetails;

        private int id;

        public int Id {
            get { return id; }
            set { id = value; }
        }

        private Game game;

        public Game Game {
            get { return game; }
            set { game = value; }
        }

        private string startTime;

        public string StartTime {
            get { return startTime; }
            set { startTime = value; }
        }

        private double minimalBet;

        public double MinimalBet {
            get { return minimalBet; }
            set { minimalBet = value; }
        }
            
        public GameDetailsViewModel(Game game, GameDetails gameDetails)
        {
            this.game = game;
            this.id = gameDetails.Id;
            this.startTime = gameDetails.StartTime;
            this.minimalBet = gameDetails.MinimalBet;
        }
    }
}
