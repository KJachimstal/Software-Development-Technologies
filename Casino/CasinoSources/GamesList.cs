using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CasionSources
{
    [XmlRoot("GamesList")]
    public class GamesList
    {
        public GamesList()
        {
            Games = new List<Game>();
        }

        [XmlElement("Game")]
        public List<Game> Games { get; set; }
    }
}
