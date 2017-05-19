using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using FACULTATIVE_REINSURANCE.View_model;

namespace FACULTATIVE_REINSURANCE.Commands
{
    class RelayCommand:ICommand
    {
        public Action<object> _execute;
        public Predicate<object> _canExecute;
        public RelayCommand(Action<object> execute, Predicate<object> canExecute=null)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }
    }
}
