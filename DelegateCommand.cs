public class DelegateCommand : ICommand
{
  private readonly Action<object> _execute;
  private readonly Predicate<object> _canExecute;
  
  public evene EventHandler CanExecuteChanged;
  
  public DelegateCommand(Predicate<object> canExecute, Action<object> execute) => (canExecute, execute) = (_canExecute, _execute);
  
  public DelegateCommand(Action<object> execute) : this (null, execute) { }
  
  public bool CanExecute(object parameter) => _canExecute?.Invoce(parameter) ?? true;
  public bool Execute(object parameter) => _execute?.Invoke(parameter);
  
  public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
