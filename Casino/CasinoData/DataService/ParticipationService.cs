using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoLibrary;

namespace CasinoData
{
    public partial class DataService
    {
        public string PrintParticipation(List<Participation> participations)
        {
            string participationString = "";

            foreach (Participation participation in participations)
            {
                participationString += participation;

                if (participations.LastIndexOf(participation) != participations.Count)
                {
                    participationString += ", ";
                }
            }

            return participationString;
        }

        public void AddParticipations(Participation participation)
        {
            if (!dataRepository.GetAllParticipations().Contains(participation))
            {
                dataRepository.AddParticipation(participation);
            } else
            {
                throw new Exception("Participation alredy exists!");
            }
        }

        public bool DeleteParticipation(Participation participation)
        {
            if (dataRepository.GetAllParticipations().Contains(participation))
            {
                dataRepository.DeleteParticipation(participation);
                return true;
            }
            else
            {
                throw new Exception("Participation does not exists!");
            }
        }

        public void UpdateParticipation(Participation oldParticipation, Participation newParticipation)
        {
            if (dataRepository.GetAllParticipations().Contains(oldParticipation))
            {
                dataRepository.UpdateParticipation(oldParticipation, newParticipation);
            }
            else
            {
                throw new Exception("Participation does not exists!");
            }
        }
    }
}
