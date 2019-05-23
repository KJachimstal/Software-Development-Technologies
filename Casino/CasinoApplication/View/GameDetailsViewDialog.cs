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
            GetDialog().Close();
        }

        public void ShowDialog()
        {
            GetDialog().Show();
        }

        private GameDetailsView GetDialog()
        {
            return null;
        }

        void view_Closed(object sender, EventArgs e)
        {
            view = null;
        } 
    }
}
