﻿using System;
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
            GetDialog().DataContext = viewModel;
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
            if (view == null)
            {
                view = new GameDetailsView();
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
