using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoLibrary
{
    public class GameDetail
    {
        private Game game;

        public Game Game {
            get { return game; }
            set { game = value; }
        }

        private DateTimeOffset startTime;

        public DateTimeOffset StartTime {
            get { return startTime; }
            set { startTime = value; }
        }

        private double minimalBet;

        public double MinimalBet {
            get { return minimalBet; }
            set { minimalBet = value; }
        }

        public GameDetail(Game game, DateTimeOffset startTime, double minimalBet)
        {
            this.game = game;
            this.startTime = startTime;
            this.minimalBet = minimalBet;
        }
    }
}
