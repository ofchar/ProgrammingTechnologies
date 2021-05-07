using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Presentation.ViewModel.MVVMLight
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _Execute;
        private readonly Predicate<object> _CanExecute;


        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _CanExecute = canExecute;
        }


        public bool CanExecute(object param)
        {
            return _CanExecute == null ? true : _CanExecute(param);
        }

        public virtual void Execute(object param)
        {
            _Execute.Invoke(param);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;

            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}
