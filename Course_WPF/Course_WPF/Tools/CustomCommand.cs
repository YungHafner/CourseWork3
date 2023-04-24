using System;
using System.Windows.Input;

namespace Course_WPF.Tools
{
    public class CustomCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        Action Action;

        public CustomCommand(Action action)
        {
            Action = action;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Action();
        }
    }
}
