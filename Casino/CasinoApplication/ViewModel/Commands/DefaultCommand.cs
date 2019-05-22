using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CasinoApplication.ViewModel.Commands
{
    class DefaultCommand : ICommand
    {

        private Action<object> execute;
        private Predicate<object> canExecute;

        public event EventHandler CanExecuteChanged;

        public DefaultCommand(Action<object> executeDelegate, Predicate<object> canExecuteDelegate)
        {
            execute = executeDelegate;
            canExecute = canExecuteDelegate;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter); 
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
