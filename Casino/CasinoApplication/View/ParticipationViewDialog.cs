using CasinoApplication.Interfaces;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApplication.View
{
    public class ParticipationViewDialog : IModalDialog
    {
        Participation participation;
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

        private ParticipationView GetDialog()
        {
            return null;
        }
    }
}
