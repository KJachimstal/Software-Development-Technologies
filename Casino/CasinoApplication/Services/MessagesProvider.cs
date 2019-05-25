using CasinoApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApplication.Services
{
    public static class MessagesProvider
    {
        private static IMessage messageService;

        public static void RegisterMessageService(IMessage _messageService)
        {
            messageService = _messageService;
        }

    }
}
