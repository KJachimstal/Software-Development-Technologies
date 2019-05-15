using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoData;
using CasinoLibrary;
using System.Collections.ObjectModel;

namespace CasinoSources
{
    class ConstantSource : IDataSource
    {
        public void Fill(DataContext dataContext)
        {
            List<Client> clients = dataContext.Clients;
            Dictionary<int, Game> games = dataContext.Games;
            ObservableCollection<GameDetail> gameDetails = dataContext.GameDetails;
            List<Participation> participations = dataContext.Participations;


            Client client1 = new Client(1, "Jennifer", "Bender");
            Client client2 = new Client(2, "Micheal", "Doyle");
            Client client3 = new Client(3, "Charlie", "Roach");
            Client client4 = new Client(4, "Sanaa", "Lee");
            Client client5 = new Client(5, "Sadie", "Mejia");
            Client client6 = new Client(6, "Kallie", "Fuller");
            Client client7 = new Client(7, "Quinton", "Garrison");
            Client client8 = new Client(8, "Lilah", "Fields");
            Client client9 = new Client(9, "Omar", "Hodges");
            Client client10 = new Client(10, "Kane", "Stafford");

            Game game1 = new Game(1, "Poker", Game.GameType.POKER);
            Game game2 = new Game(2, "Bridge", Game.GameType.BRIDGE);
            Game game3 = new Game(3, "Ruletka", Game.GameType.ROULETTE);

            DateTimeOffset date = new DateTimeOffset(2019, 05, 15, 10, 15, 0, new TimeSpan(1, 0, 0));

            GameDetail gameDetail1 = new GameDetail(game1, date, 500);
            GameDetail gameDetail2 = new GameDetail(game2, date, 100);
            GameDetail gameDetail3 = new GameDetail(game3, date, 300);

            Participation participation1 = new Participation(client1, gameDetail1, 600);
            Participation participation2 = new Participation(client2, gameDetail2, 130);
            Participation participation3 = new Participation(client3, gameDetail3, 400);

            clients.Add(client1);
            clients.Add(client2);
            clients.Add(client3);
            clients.Add(client4);
            clients.Add(client5);
            clients.Add(client6);
            clients.Add(client7);
            clients.Add(client8);
            clients.Add(client9);
            clients.Add(client10);

            games.Add(1, game1);
            games.Add(2, game2);
            games.Add(3, game3);

            gameDetails.Add(gameDetail1);
            gameDetails.Add(gameDetail2);
            gameDetails.Add(gameDetail3);

            participations.Add(participation1);
            participations.Add(participation2);
            participations.Add(participation3);
        }
    }


}
