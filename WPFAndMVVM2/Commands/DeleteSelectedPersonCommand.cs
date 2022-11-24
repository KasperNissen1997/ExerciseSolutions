using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFAndMVVM2.ViewModels;

namespace WPFAndMVVM2.Commands
{
    public class DeleteSelectedPersonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute (object parameter) {
            if (parameter is MainViewModel mvm) {
                bool result = false;

                if (mvm.SelectedPerson is not null) 
                    result = true;

                CommandManager.InvalidateRequerySuggested();

                return result;
            }
            else {
                Trace.WriteLine("Illegal parameter argument");
                return false;
            }
        }

        public void Execute (object parameter) {
            if (parameter is MainViewModel mvm) {
                mvm.DeleteSelectedPerson();
            }
            else
                Trace.WriteLine("Illegal parameter argument.");
        }
    }
}
