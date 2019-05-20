using CasinoData;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public RandomDataSource(int multiplier)
        {
            this.multiplier = multiplier;
        }

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
            dataContext.GameDetails = new ObservableCollection<GameDetails>();
            for (int i = 1; i <= 300 * multiplier; i++)
            {
                Game game = dataContext.Games[random.Next(1, 400 * multiplier)];
                GameDetails gameDetails = new GameDetails()
                {
                    Id = i,
                    Game = game,
                    startTime = DateTimeOffset.Now,
                    MinimalBet = random.NextDouble() * 10,
                };
                dataContext.GameDetails.Add(gameDetails);
            }
        }

        private void FillParticipations()
        {
            dataContext.Participations = new List<Participation>();
            for (int i = 1; i <= 800; i++)
            {
                Client client = dataContext.Clients[random.Next(1, 500 * multiplier)];
                GameDetails gameDetails = dataContext.GameDetails[random.Next(1, 300 * multiplier)];
                Participation participation = new Participation()
                {
                    Client = client,
                    GameDetails = gameDetails,
                    Bet = random.NextDouble() * 20,
                };
                dataContext.Participations.Add(participation);
            }
        }

        private string GetRandomString(int length)
        {
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
