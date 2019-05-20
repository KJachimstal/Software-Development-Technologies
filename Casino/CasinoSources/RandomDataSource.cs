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
        private DataContext dataContext;
        private int multiplier = 1;
        private static Random random = new Random();
        const string chars = "abcdefghijklmnopqrstuvwxyz";

        public void Fill(DataContext dataContext)
        {
            this.dataContext = dataContext;
            FillClients();
            FillGames();
            FillGamesDetails();
            FillParticipations();
        }

        private void FillClients()
        {
            dataContext.Clients = new List<Client>();
            for (int i = 1; i <= 500 * multiplier; i++)
            {
                Client client = new Client()
                {
                    ClientNumber = i,
                    FirstName = GetRandomString(random.Next(5, 10)),
                    LastName = GetRandomString(random.Next(5, 15)),
                };
                dataContext.Clients.Add(client);
            }
        }

        private void FillGames()
        {
            dataContext.Games = new Dictionary<int, Game>();
            for (int i = 1; i <= 400 * multiplier; i++)
            {
                Game game = new Game()
                {
                    Id = i,
                    Name = GetRandomString(random.Next(5, 10)),
                    Type = Game.GameType.POKER,
                };
                dataContext.Games.Add(i, game);
            }
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
