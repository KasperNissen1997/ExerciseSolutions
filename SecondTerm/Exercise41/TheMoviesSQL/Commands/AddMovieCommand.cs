using System;
using System.Windows.Input;
using TheMovies.MVVM.Models;
using TheMovies.MVVM.ViewModels;
using TheMovies.MVVM.ViewModels.Persistence;
using TheMovies.MVVM.Views;

namespace TheMovies.Commands
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
                        DateOnly premiereDate = DateOnly.FromDateTime(createMovieVM.PremiereDateTime);

                        Movie movie = MovieRepository.Instance.Create(createMovieVM.Title, createMovieVM.Genre, duration, createMovieVM.Instructor, premiereDate);

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
