using CasinoApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CasinoApplication.Common
{
    class DefaultMessage : IMessage
    {
        public void Show(string message, string title, MessageBoxButton buttons, MessageBoxImage image)
        {
            MessageBox.Show(message, title, buttons, image);
        }
    }
}
