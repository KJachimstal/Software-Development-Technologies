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
        public void AddGame(Game game)
        {
            dataContext.Games.Add(game.Id, game);
        }

        public Game getGame(int id)
        {
            return dataContext.Games[id];
        }
    }
}
