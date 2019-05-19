using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CasionSources
{
    [XmlRoot("GamesDetailsList")]
    public class GamesDetailsList
    {
        public GamesDetailsList()
        {
            GamesDetails = new List<GameDetails>();
        }

        [XmlElement("GameDetails")]
        public List<GameDetails> GamesDetails { get; set; }
    }
}
