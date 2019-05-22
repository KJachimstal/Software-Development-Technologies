using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CasinoApplication.ViewModel.Commands
{
    public class AddCommand : ICommand
    {
        private Action<object> execute;

        public AddCommand(Action<object> executeDelegate)
        {
            execute = executeDelegate;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute(this);
        }
    }
}
