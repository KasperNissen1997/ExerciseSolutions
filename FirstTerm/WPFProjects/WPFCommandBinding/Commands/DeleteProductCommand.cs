using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFCommandBinding.ViewModels;

namespace WPFCommandBinding.Commands
{
    public class DeleteProductCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute (object? parameter) {
            if (parameter is MainViewModel mainVM) {
                bool result = false;

                if (mainVM.SelectedProduct is not null)
                    result = true;

                CommandManager.InvalidateRequerySuggested();

                return result;
            }

            return false;
        }

        public void Execute (object? parameter) {
            if (parameter is MainViewModel mainVM) {
                mainVM.DeleteProduct();
                Trace.WriteLine("Deleted the selected product.");
            }
            else 
                throw new ArgumentException("Illegal parameter argument.");
        }
    }
}
