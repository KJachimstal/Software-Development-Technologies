using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CasionSources
{
    [XmlRoot("ParticipationsList")]
    class ParticipationsList
    {
        public ParticipationsList()
        {
            Participations = new List<Participation>();
        }

        [XmlElement("Participation")]
        public List<Participation> Participations { get; set; }
    }
}
