﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoLibrary;

namespace CasinoData
{
    public class DataContext
    {
        private ObservableCollection<Client> clients;

        public ObservableCollection<Client> Clients {
            get { return clients; }
            set { clients = value; }
        }

        private Dictionary<int, Game> games;

        public Dictionary<int, Game> Games {
            get { return games; }
            set { games = value; }
        }

        private ObservableCollection<GameDetails> gameDetails;

        public ObservableCollection<GameDetails> GameDetails {
            get { return gameDetails; }
            set { gameDetails = value; }
        }

        private List<Participation> participations;

        public List<Participation> Participations {
            get { return participations; }
            set { participations = value; }
        }

        public DataContext(ObservableCollection<Client> clients, Dictionary<int, Game> games, ObservableCollection<GameDetails> gameDetails, List<Participation> participations)
        {
            this.clients = clients;
            this.games = games;
            this.gameDetails = gameDetails;
            this.participations = participations;
        }

        public DataContext() { }
    }
}
