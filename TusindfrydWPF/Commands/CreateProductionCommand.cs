using System;
using System.Diagnostics;
using System.Windows.Input;
using TusindfrydWPF.ViewModels;
using TusindfrydWPF.Views;


namespace TusindfrydWPF.Commands
{
    public class CreateProductionCommand : ICommand
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
                // creates a higher coupling between the MainViewModel and the StartProductionDialogue,
                // when MainViewModel is a parameter in the constructor of the StartProductionDialogue.
                StartProductionDialogue dialogue = new StartProductionDialogue(mvm);
                Trace.WriteLine("Opened a dialogue for starting a production.");
                dialogue.ShowDialog();
            }
            else
                throw new ArgumentException("Illegal parameter argument.");
        }
    }
}
