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
        public void AddGame(Game game)
        {
            dataContext.Games.Add(game);
            dataContext.SaveChanges();
        }

        public Game GetGame(int id)
        {
            return dataContext.Games.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Game> GetAllGames()
        {
            return dataContext.Games;
        }

        public void UpdateGame(Game oldGame, Game newGame)
        {
            oldGame.Id = newGame.Id;
            oldGame.Name = newGame.Name;
            oldGame.Type = newGame.Type;
            dataContext.SaveChanges();
        }

        public bool DeleteGame(Game game)
        {
            dataContext.Games.Remove(game);
            dataContext.SaveChanges();
            return true;
        }
    }
}
