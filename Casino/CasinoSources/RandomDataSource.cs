using CasinoData;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasionSources
{
    class RandomDataSource : IDataSource
    {

        private int multiplier = 1;
        private static Random random = new Random();
        const string chars = "abcdefghijklmnopqrstuvwxyz";

        public void Fill(DataContext dataContext)
        {
            FillClients();
            FillGames();
            FillGamesDetails();
            FillParticipations();
        }

        private void FillClients()
        {
            for (int i = 1; i <= 500 * multiplier; i++)
            {
                Client client = new Client()
                {
                    ClientNumber = i,
                    FirstName = GetRandomString(random.Next(5, 10)),
                    LastName = GetRandomString(random.Next(5, 15)),
                };
            }
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

        public void SetMultiplier(int multiplier)
        {
            this.multiplier = multiplier;
        }

        private string GetRandomString(int length)
        {
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
