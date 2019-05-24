using CasinoApplication.Model;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApplication.ViewModel
{
    class ParticipationViewModel
    {
        private ObservableCollection<GameDetails> gameDetails;

        public ObservableCollection<GameDetails> GameDetails {
            get {
                gameDetails = Data.DataRepository.GetAllGameDetails();
                return gameDetails;
            }

        }
    }
}
