﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class GameDetails
    {
        private Game game;

        public Game Game {
            get { return game; }
            set { game = value; }
        }

        private DateTimeOffset startTime;

        public DateTimeOffset StartTime {
            get { return startTime; }
            set { startTime = value; }
        }

        
    }
}
