using System;
using System.Windows.Input;

namespace WpfMHilfer.view
{
    public class RelayCommand<T> : ICommand
    {
        #region Fields
        private readonly Predicate<T> _canExecute=null;
        private readonly Action<T> _execute=null;
        private ICommand deleteCommand;

        #endregion

        #region Constructor
        public RelayCommand(Action<T> execute): this(execute,null)
        {
            _execute = execute;
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if(execute==null)
            {
                throw new ArgumentNullException("Execute");
            }
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(ICommand deleteCommand)
        {
            this.deleteCommand = deleteCommand;
        }
        #endregion

        #region ICommand Members
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if(_canExecute!=null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
        #endregion
    }
}