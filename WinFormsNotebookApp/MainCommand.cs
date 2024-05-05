using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WinFormsNotebookApp
{
    public class MainCommand : ICommand
    {
        Action<object?> action;
        Predicate<object?>? predicate;

        public MainCommand(Action<object?> action, Predicate<object?>? predicate = null)
        {
            this.action = action;
            this.predicate = predicate;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (predicate is not null)
                return predicate(parameter);
            else
                return true;
        }

        public void Execute(object? parameter)
        {
            action.Invoke(parameter);
        }
    }
}
