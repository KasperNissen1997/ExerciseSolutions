using System;
using System.Windows.Input;
using TheMovies.MVVM.ViewModels;

namespace TheMovies.Commands
{
    public class RemoveMovieCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is MainViewModel vm)
            {
                if (vm.SelectedMovie != null)
                    return true;

                return false;
            }

            return false;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel vm)
            {
                vm.Movies.Remove(vm.SelectedMovie);
                
                vm.SelectedMovie.Delete();

                vm.SelectedMovie = null;
            }
            else
                throw new NotImplementedException();
        }
    }
}
