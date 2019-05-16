using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoLibrary;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CasinoData
{
    public partial class DataService
    {
        public string PrintGameDetails(ObservableCollection<GameDetails> gameDetails)
        {
            string gameDetailsString = "";

            for (int i = 0; i <= gameDetails.Count; i++)
            {
                gameDetailsString += gameDetails;

                if (i + 1 != gameDetails.Count)
                {
                    gameDetailsString += ", ";
                }
            }

            return gameDetailsString;
        }

        public void AddGameDetails(GameDetails gameDetails)
        {
            if (!dataRepository.GetAllGameDetails().Contains(gameDetails))
            {
                dataRepository.AddGameDetails(gameDetails);
            } else
            {
                throw new Exception("GameDetails alredy exists!");
            }
        }

        public void DeleteGameDetails(GameDetails gameDetails)
        {
            if (dataRepository.GetAllGameDetails().Contains(gameDetails))
            {
                dataRepository.DeleteGameDetails(gameDetails);
            }
            else
            {
                throw new Exception("GameDetails does not exists!");
            }
        }

        public void UpdateGameDetails(GameDetails oldGameDetails, GameDetails newGameDetails)
        {
            if (dataRepository.GetAllGameDetails().Contains(oldGameDetails))
            {
                dataRepository.UpdateGameDetails(oldGameDetails, newGameDetails);
            }
            else
            {
                throw new Exception("GameDetails does not exists!");
            }
        }

        public List<GameDetails> GameDetailsBetweenDateTime(DateTimeOffset beginDate, DateTimeOffset endDate)
        {
            List<GameDetails> gameDetailsList = new List<GameDetails>();

            foreach (GameDetails gameDetails in dataRepository.GetAllGameDetails())
            {
                if (gameDetails.StartTime >= beginDate && gameDetails.StartTime <= endDate)
                {
                    gameDetailsList.Add(gameDetails);
                }
            }

            return gameDetailsList;
        }

        public void HandleGameDetailsChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Game details list was changed!");
        }
    }
}
