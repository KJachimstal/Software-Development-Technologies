using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CasinoLibrary
{
    [Serializable()]
    public class GameDetails : INotifyPropertyChanged
    {
        private int id;

        [XmlElement("Id")]
        public int Id {
            get { return id; }
            set { id = value; }
        }

        private Game game;

        [XmlIgnore]
        public Game Game {
            get { return game; }
            set 
            {
                game = value;
                OnPropertyChanged("Game");
            }
        }

        private int gameId;

        [XmlAttribute("GameId")]
        public int GameId {
            get { return gameId; }
            set { gameId = value; }
        }

        public DateTimeOffset startTime;

        [XmlElement("StartTime")]
        public string StartTime {
            get { return startTime.ToString("o"); }
            set 
            {
                startTime = DateTimeOffset.Parse(value);
                OnPropertyChanged("StartTime");
            }
        }

        private double minimalBet;

        [XmlElement("MinimalBet")]
        public double MinimalBet {
            get { return minimalBet; }
            set 
            {
                minimalBet = value;
                OnPropertyChanged("MinimalBet");
            }
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
                startTime == state.startTime &&
                minimalBet == state.MinimalBet;
        }

        public override string ToString()
        {
            return game.Name + " " + startTime.ToString() + " [min-bet: " + minimalBet + "]";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
