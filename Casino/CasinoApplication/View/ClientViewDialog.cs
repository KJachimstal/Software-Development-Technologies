using CasinoApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApplication.View
{
    public class ClientViewDialog : IModalDialog
    {
        private ClientView view;

        public void BindViewModel<TViewModel>(TViewModel viewModel)
        {
            GetDialog().DataContext = viewModel;
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void ShowDialog()
        {
            GetDialog().Show();
        }

        private ClientView GetDialog()
        {
            if (view == null)
            {
                view = new ClientView();
                view.Closed += new EventHandler(view_Closed);
            }
            return view;
        }

        void view_Closed(object sender, EventArgs e)
        {
            view = null;
        }
    }
}
