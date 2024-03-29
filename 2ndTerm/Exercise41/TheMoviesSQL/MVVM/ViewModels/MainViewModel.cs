﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMoviesSQL.Commands;
using TheMoviesSQL.MVVM.Models;
using TheMoviesSQL.MVVM.ViewModels.Persistence;

namespace TheMoviesSQL.MVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MovieViewModel> _movies;
        public ObservableCollection<MovieViewModel> Movies
        {
            get { return _movies; }

            set
            {
                _movies = value;
                OnPropertyChanged(nameof(Movies));
            }
        }

        private MovieViewModel _selectedMovie;
        public MovieViewModel SelectedMovie
        {
            get
            {
                return _selectedMovie;
            }

            set
            {
                _selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));

                SelectedMovieDurationHours = SelectedMovie.Duration.Hours;
                SelectedMovieDurationMinutes = SelectedMovie.Duration.Minutes;
                OnPropertyChanged(nameof(SelectedMovieDurationHours));
                OnPropertyChanged(nameof(SelectedMovieDurationMinutes));
            }
        }

        private int _selectedMovieDurationHours;
        public int SelectedMovieDurationHours
        {
            get { return _selectedMovieDurationHours; }

            set
            {
                _selectedMovieDurationHours = value;

                OnPropertyChanged(nameof(SelectedMovieDurationHours));

                if (SelectedMovie == null)
                    return;

                SelectedMovie.Duration = new(SelectedMovieDurationHours, SelectedMovie.Duration.Minutes, 0);
            }
        }
        private int _selectedMovieDurationMinutes;
        public int SelectedMovieDurationMinutes
        {
            get { return _selectedMovieDurationMinutes; }

            set
            {
                _selectedMovieDurationMinutes = value;

                OnPropertyChanged(nameof(SelectedMovieDurationMinutes));

                if (SelectedMovie == null)
                    return;

                SelectedMovie.Duration = new(SelectedMovie.Duration.Hours, SelectedMovieDurationMinutes, 0);
            }
        }

        #region Commands
        public AddMovieCommand AddMovieCommand { get; set; } = new();
        public RemoveMovieCommand RemoveMovieCommand { get; set; } = new();
        #endregion

        #region OnChanged events
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;

            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public MainViewModel()
        {
            Movies = new ObservableCollection<MovieViewModel>();

            foreach (Movie movie in MovieRepository.Instance.RetrieveAll())
                Movies.Add(new MovieViewModel(movie));
        }
    }
}
