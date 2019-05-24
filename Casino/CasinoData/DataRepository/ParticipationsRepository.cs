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
        }

        public Participation GetParticipation(Client client)
        {
            return dataContext.Participations.FirstOrDefault(p => p.Client.Equals(client));
        }

        public ObservableCollection<Participation> GetAllParticipations()
        {
            List<Participation> participations = dataContext.Participations.ToList();
            ObservableCollection<Participation> collection = new ObservableCollection<Participation>();
            foreach (Participation participation in participations)
            {
                collection.Add(participation);
            }
            return collection;
        }

        public void UpdateParticipation(Participation oldParticipation, Participation newParticipation)
        {
            oldParticipation.Client = newParticipation.Client;
            oldParticipation.GameDetails = newParticipation.GameDetails;
            oldParticipation.Bet = newParticipation.Bet;
        }

        public bool DeleteParticipation(Participation participation)
        {
            dataContext.Participations.Remove(participation);
            return true;
        }
    }
}
