﻿using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public partial class DataRepository
    {
        public void AddClient(Client client)
        {
            dataContext.Clients.Add(client);
        }
    }
}