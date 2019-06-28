using System;
using System.Windows.Input;

namespace WpfControlsDemo.ViewModel
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Action<object> CommandAction;

        public DelegateCommand(Action<object> cmdAction)
        {
            CommandAction = cmdAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CommandAction?.Invoke(parameter);
        }
    }
}
