using System;
using System.Diagnostics;
using System.Windows.Input;
using WPFCommandBinding.ViewModels;

namespace WPFCommandBinding.Commands
{
    public class CreateProductCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute (object? parameter) {
            return true;
        }

        public void Execute (object? parameter) {
            if (parameter is MainViewModel mainVM) {
                mainVM.CreateProduct();
                Trace.WriteLine("Created a new product.");
            }
            else {
                throw new ArgumentException("Illegal parameter argument.");
            }
        }
    }
}
