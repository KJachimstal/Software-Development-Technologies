using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApplication.ViewModel
{
    class GameDetailsViewModel : ViewModel
    {
        private GameDetails gameDetails;

        private int id;

        public int Id {
            get { return id; }
            set { id = value; }
        }   

    }
}
