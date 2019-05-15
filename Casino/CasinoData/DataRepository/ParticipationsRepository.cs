using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public partial class DataRepository
    {
        public void AddParticipation(Participation participation)
        {
            dataContext.Participations.Add(participation);
        }

        public Participation GetParticipation(Client client)
        {
            return dataContext.Participations.Single(p => p.Client == client);
        }

        public IEnumerable<Participation> GetAllParticipations()
        {
            return dataContext.Participations;
        }

        public void UpdateParticipation(Participation oldParticipation, Participation newParticipation)
        {
            oldParticipation.Client = newParticipation.Client;
            oldParticipation.GameDetail = newParticipation.GameDetail;
            oldParticipation.Bet = newParticipation.Bet;
        }

        public void DeleteParticipation(Participation participation)
        {
            dataContext.Participations.Remove(participation);
        }
    }
}
