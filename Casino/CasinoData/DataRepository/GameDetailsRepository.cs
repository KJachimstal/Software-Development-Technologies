using CasinoLibrary;
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
            dataContext.SaveChanges();
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
            oldGameDetails.Game = newGameDetails.Game;
            oldGameDetails.StartTime = newGameDetails.StartTime;
            oldGameDetails.MinimalBet = newGameDetails.MinimalBet;
            dataContext.SaveChanges();
        }

        public bool DeleteGameDetails(GameDetails gameDetails)
        {
            dataContext.GamesDetails.Remove(gameDetails);
            dataContext.SaveChanges();
            return true;
        }
    }
}
