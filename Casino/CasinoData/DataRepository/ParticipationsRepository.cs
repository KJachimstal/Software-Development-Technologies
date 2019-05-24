using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            dataContext.SaveChanges();
        }

        public Participation GetParticipation(Client client)
        {
            return dataContext.Participations.FirstOrDefault(p => p.Client.Equals(client));
        }

        public IEnumerable<Participation> GetAllParticipations()
        {
            return dataContext.Participations;
        }

        public void UpdateParticipation(Participation oldParticipation, Participation newParticipation)
        {
            oldParticipation.Client = newParticipation.Client;
            oldParticipation.GameDetails = newParticipation.GameDetails;
            oldParticipation.Bet = newParticipation.Bet;
            dataContext.SaveChanges();
        }

        public bool DeleteParticipation(Participation participation)
        {
            dataContext.Participations.Remove(participation);
            dataContext.SaveChanges();
            return true;
        }
    }
}
