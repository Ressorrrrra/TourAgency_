using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TourAgency_.ViewModels
{
    public class ViewModelCommand : ICommand
    {
        private Action<object?>? execute;
        private Predicate<object?>? executePredicate;


        public ViewModelCommand()
        {
                
        }

        public ViewModelCommand(Action<object> action)
        {
            execute = action;
            executePredicate = null;
        }

        public ViewModelCommand(Action<object> action, Predicate<object> predicate)
        {
            execute = action;
            executePredicate = predicate;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return executePredicate == null ? true : executePredicate(parameter);
        }

        public void Execute(object? parameter)
        {
            execute?.Invoke(parameter);
        }
    }
}
