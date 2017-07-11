using System;
using System.Windows.Input;

namespace CodenameFiles.Handlers
{
    public class CommandHandlerBase : ICommand
    {
        private Action _action;
        private bool _canExecute;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
