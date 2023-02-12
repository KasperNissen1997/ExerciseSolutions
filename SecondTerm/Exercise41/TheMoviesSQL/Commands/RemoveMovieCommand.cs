using System;
using System.Windows.Input;
using TheMoviesSQL.MVVM.ViewModels;

namespace TheMoviesSQL.Commands
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
                vm.SelectedMovie.Delete();

                vm.Movies.Remove(vm.SelectedMovie);
                vm.SelectedMovie = null;
            }
            else
                throw new NotImplementedException();
        }
    }
}
