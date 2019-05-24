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
    public class Participation : INotifyPropertyChanged
    {
        private int id;

        [XmlElement("Id")]
        public int Id {
            get { return id; }
            set { id = value; }
        }

        private Client client;

        [XmlIgnore]
        public Client Client {
            get { return client; }
            set 
            {
                client = value;
                OnPropertyChanged("Client");
            }
        }

        private GameDetails gameDetail;

        [XmlIgnore]
        public GameDetails GameDetails {
            get { return gameDetail; }
            set 
            {
                gameDetail = value;
                OnPropertyChanged("GameDetails");
            }
        }

        private double bet;

        [XmlElement("Bet")]
        public double Bet {
            get { return bet; } 
            set 
            {
                bet = value;
                OnPropertyChanged("Bet");
            }
        }

        public Participation(Client client, GameDetails gameDetail, double bet)
        {
            this.client = client;
            this.gameDetail = gameDetail;
            this.bet = bet;
        }

        public Participation() { }

        public override bool Equals(object obj)
        {
            var state = obj as Participation;
            return state != null &&
                client == state.Client &&
                gameDetail == state.GameDetails &&
                bet == state.Bet;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
