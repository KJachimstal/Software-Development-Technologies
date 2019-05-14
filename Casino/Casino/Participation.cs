using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class Participation
    {
        private Client client;

        public Client Client {
            get { return client; }
            set { client = value; }
        }

        private GameDetails gameDetails;

        public GameDetails GameDetails {
            get { return gameDetails; }
            set { gameDetails = value; }
        }

        private double bet;

        public double Bet {
            get { return bet; } 
            set { bet = value; }
        }

        public Participation(Client client, GameDetails gameDetails, double bet)
        {
            this.client = client;
            this.gameDetails = gameDetails;
            this.bet = bet;
        }
    }
}
