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
        }

        public Game GetGame(int id)
        {
            return dataContext.Games.FirstOrDefault(g => g.Id == id);
        }

        public ObservableCollection<Game> GetAllGames()
        {
            List<Game> games = dataContext.Games.ToList();
            ObservableCollection<Game> collection = new ObservableCollection<Game>();
            foreach (Game game in games)
            {
                collection.Add(game);
            }
            return collection;
        }

        public void UpdateGame(Game oldGame, Game newGame)
        {
            oldGame.Id = newGame.Id;
            oldGame.Name = newGame.Name;
            oldGame.Type = newGame.Type;
        }

        public bool DeleteGame(Game game)
        {
            dataContext.Games.Remove(game);
            return true;
        }
    }
}
