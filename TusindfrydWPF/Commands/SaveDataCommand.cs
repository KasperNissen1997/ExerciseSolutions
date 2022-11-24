using System;
using System.Diagnostics;
using System.Windows.Input;
using TusindfrydWPF.ViewModels;

namespace TusindfrydWPF.Commands
{
    public class SaveDataCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute (object? parameter) 
        {
            return true;
        }

        public void Execute (object? parameter) 
        {
            if (parameter is MainViewModel mvm) 
            {
                mvm.SaveAllRepositories();
                Trace.WriteLine("All repositories have been saved!");
            }
            else
                throw new ArgumentException("Illegal parameter argument.");
        }
    }
}
