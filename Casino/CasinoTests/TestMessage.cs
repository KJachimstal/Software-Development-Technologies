using CasinoApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CasinoTests
{
    class TestMessage : IMessage
    {
        public MessageBoxResult Show(string title, string message, MessageBoxButton buttons, MessageBoxImage image)
        {
            // do nothing
            return MessageBoxResult.OK;
        }
    }
}
