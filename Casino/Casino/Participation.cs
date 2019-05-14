using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoLibrary
{
    public class Participation
    {
        private Client client;

        public Client Client {
            get { return client; }
            set { client = value; }
        }

        private GameDetail gameDetail;

        public GameDetail GameDetail {
            get { return gameDetail; }
            set { gameDetail = value; }
        }

        private double bet;

        public double Bet {
            get { return bet; } 
            set { bet = value; }
        }

        public Participation(Client client, GameDetail gameDetail, double bet)
        {
            this.client = client;
            this.gameDetail = gameDetail;
            this.bet = bet;
        }
    }
}
