using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApplication.Interfaces
{
    interface IDialog
    {
        void AssignViewModel<TViewModel>(TViewModel viewModel);
        void ShowDialog();
        void Close();
    }
}
