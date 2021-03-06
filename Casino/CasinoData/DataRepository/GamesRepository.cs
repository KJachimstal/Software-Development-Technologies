﻿using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public partial class DataRepository
    {
        public void AddGame(Game game)
        {
            dataContext.Games.Add(game.Id, game);
        }

        public Game GetGame(int id)
        {
            return dataContext.Games[id];
        }

        public Dictionary<int, Game> GetAllGames()
        {
            return dataContext.Games;
        }

        public void UpdateGame(Game oldGame, Game newGame)
        {
            oldGame.Id = newGame.Id;
            oldGame.Name = newGame.Name;
            oldGame.Type = newGame.Type;
        }

        public void DeleteGame(Game game)
        {
            dataContext.Games.Remove(game.Id);
        }
    }
}
