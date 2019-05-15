using CasinoLibrary;
using System;
using System.Collections.Generic;
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


    }
}
