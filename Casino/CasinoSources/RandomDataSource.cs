using CasinoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasionSources
{
    class RandomDataSource : IDataSource
    {
        public void Fill(DataContext dataContext)
        {
            FillClients();
            FillGames();
            FillGamesDetails();
            FillParticipations();
        }

        private void FillClients()
        {

        }

        private void FillGames()
        {

        }

        private void FillGamesDetails()
        {

        }

        private void FillParticipations()
        {

        }
    }
}
