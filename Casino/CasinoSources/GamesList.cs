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
    class GamesList
    {
        public GamesList(List<Game> games)
        {
            Games = games;
        }

        [XmlElement("Game")]
        public List<Game> Games { get; set; }
    }
}
