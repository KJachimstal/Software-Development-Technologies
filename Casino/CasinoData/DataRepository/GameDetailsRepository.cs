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
            dataContext.GameDetails.Add(gameDetails);
        }

        public GameDetails GetGameDetails(Game game)
        {
            return dataContext.GameDetails.Single(gd => gd.Game.Equals(game));
        }

        public ObservableCollection<GameDetails> GetAllGameDetails()
        {
            return dataContext.GameDetails;
        }

        public void UpdateGameDetails(GameDetails oldGameDetails, GameDetails newGameDetails)
        {
            GameDetails gameDetails = oldGameDetails;
            var item = dataContext.GameDetails.FirstOrDefault(gd => gd.Equals(oldGameDetails));
            if (item != null)
            {
                item.Game = newGameDetails.Game;
                item.StartTime = newGameDetails.StartTime;
                item.MinimalBet = newGameDetails.MinimalBet;
            }
        }

        public bool DeleteGameDetails(GameDetails gameDetails)
        {
            if (dataContext.GameDetails.Remove(gameDetails))
            {
                return true;
            }

            return false;
        }
    }
}
