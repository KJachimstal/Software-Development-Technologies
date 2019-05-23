using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoApplication.Interfaces;

namespace CasinoApplication.View
{
    public class GameDetailsViewDialog : IModalDialog
    {
        private GameDetailsView view;

        public void BindViewModel<TViewModel>(TViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void ShowDialog()
        {
            throw new NotImplementedException();
        }

        private GameDetailsView GetDialog()
        {
            return null;
        }
    }
}
