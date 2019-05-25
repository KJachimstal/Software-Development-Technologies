﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CasinoApplication.Interfaces
{
    public interface IMessage
    {
        void Show(string title, string message, MessageBoxButton buttons, MessageBoxImage image);
    }
}
