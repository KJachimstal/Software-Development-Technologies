using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CasinoLibrary
{
    [Serializable()]
    public class Participation
    {
        private Client client;

        [XmlIgnore]
        public Client Client {
            get { return client; }
            set { client = value; }
        }

        private GameDetails gameDetail;

        [XmlIgnore]
        public GameDetails GameDetails {
            get { return gameDetail; }
            set { gameDetail = value; }
        }

        [XmlAttribute("ClientId")]
        public int ClientId { get; set; }

        [XmlAttribute("GameDetailsId")]
        public int GameDetailsId { get; set; }

        private double bet;

        [XmlElement("Bet")]
        public double Bet {
            get { return bet; } 
            set { bet = value; }
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
    }
}
