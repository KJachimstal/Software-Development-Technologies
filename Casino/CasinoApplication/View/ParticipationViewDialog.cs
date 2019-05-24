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
        ParticipationView view;
        public void BindViewModel<TViewModel>(TViewModel viewModel)
        {
            GetDialog().DataContext = viewModel;
        }

        public void Close()
        {
            GetDialog().Close();
        }

        public void ShowDialog()
        {
            GetDialog().Show()
        }

        private ParticipationView GetDialog()
        {
            if (view == null)
            {
                view = new ParticipationView();
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
