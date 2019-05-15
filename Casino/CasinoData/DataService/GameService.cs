using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoLibrary;

namespace CasinoData
{
    public partial class DataService
    {
        public string PrintGame(Dictionary<int, Game> games)
        {
            string gameString = "";

            for (int i = 0; i<= games.Count; i++)
            {
                gameString += games.Keys.ElementAt(i);
                
                if (i+1 != games.Count)
                {
                    gameString += ", ";
                }
            }

            return gameString;
        }

        public void AddGame(Game game)
        {
            if(!dataRepository.GetAllGames().ContainsValue(game))
            {
                dataRepository.AddGame(game);
            } else
            {
                throw new Exception("Game alredy exists!");
            }
        }

        public void DeleteGame(Game game)
        {
            if (dataRepository.GetAllGames().ContainsValue(game))
            {
                dataRepository.DeleteGame(game);
            }
            else
            {
                throw new Exception("Game does not exists!");
            }
        }

        public void UpdateGame(Game oldGame, Game newGame)
        {
            if (dataRepository.GetAllGames().ContainsValue(oldGame))
            {
                dataRepository.UpdateGame(oldGame, newGame);
            }
            else
            {
                throw new Exception("Game does not exists!");
            }
        }
    }
}
