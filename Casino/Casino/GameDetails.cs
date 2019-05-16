using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CasinoLibrary
{
    [Serializable()]
    public class GameDetails
    {
        private Game game;

        [XmlElement("Game")]
        public Game Game {
            get { return game; }
            set { game = value; }
        }

        private DateTimeOffset startTime;

        [XmlElement("StartTime")]
        public DateTimeOffset StartTime {
            get { return startTime; }
            set { startTime = value; }
        }

        private double minimalBet;

        [XmlElement("MinimalBet")]
        public double MinimalBet {
            get { return minimalBet; }
            set { minimalBet = value; }
        }

        public GameDetails(Game game, DateTimeOffset startTime, double minimalBet)
        {
            this.game = game;
            this.startTime = startTime;
            this.minimalBet = minimalBet;
        }

        public GameDetails() { }

        public override bool Equals(object obj)
        {
            var state = obj as GameDetails;
            return state != null &&
                game == state.Game &&
                startTime == state.StartTime &&
                minimalBet == state.MinimalBet;
        }

        public override string ToString()
        {
            return game.Name + " " + startTime.ToString() + " [min-bet: " + minimalBet + "]";
        }
    }
}
