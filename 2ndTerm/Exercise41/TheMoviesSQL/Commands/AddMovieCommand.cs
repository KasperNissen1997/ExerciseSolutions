using System;
using System.Windows.Input;
using TheMoviesSQL.MVVM.Models;
using TheMoviesSQL.MVVM.ViewModels;
using TheMoviesSQL.MVVM.ViewModels.Persistence;
using TheMoviesSQL.MVVM.Views;

namespace TheMoviesSQL.Commands
{
    public class AddMovieCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel vm)
            {
                AddMovieView createMovieView = new();
                createMovieView.ShowDialog();

                if (createMovieView.DialogResult == true)
                {
                    if (createMovieView.DataContext is AddMovieViewModel createMovieVM)
                    {
                        TimeSpan duration = new(createMovieVM.DurationHours, createMovieVM.DurationMinutes, 0);

                        Movie movie = MovieRepository.Instance.Create(createMovieVM.Title, createMovieVM.Genre, duration, createMovieVM.Instructor, createMovieVM.PremiereDateTime);

                        MovieViewModel movieVM = new(movie);

                        vm.Movies.Add(movieVM);
                        vm.SelectedMovie = movieVM;
                    }
                }
            }
            else
                throw new NotImplementedException();
        }
    }
}
