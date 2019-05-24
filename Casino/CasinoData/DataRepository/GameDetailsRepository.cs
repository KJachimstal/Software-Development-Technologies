﻿using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public partial class DataRepository
    {
        public void AddGameDetails(GameDetails gameDetails)
        {
            dataContext.GamesDetails.Add(gameDetails);
        }

        public GameDetails GetGameDetails(Game game)
        {
            return dataContext.GamesDetails.FirstOrDefault(gd => gd.Game.Equals(game));
        }

        public IEnumerable<GameDetails> GetAllGameDetails()
        {
            return dataContext.GamesDetails;
        }

        public void UpdateGameDetails(GameDetails oldGameDetails, GameDetails newGameDetails)
        {
            GameDetails gameDetails = oldGameDetails;
            var item = dataContext.GamesDetails.FirstOrDefault(gd => gd.Equals(oldGameDetails));
            if (item != null)
            {
                item.Game = newGameDetails.Game;
                item.StartTime = newGameDetails.StartTime;
                item.MinimalBet = newGameDetails.MinimalBet;
            }
        }

        public bool DeleteGameDetails(GameDetails gameDetails)
        {
            dataContext.GamesDetails.Remove(gameDetails);
            return true;
        }
    }
}
