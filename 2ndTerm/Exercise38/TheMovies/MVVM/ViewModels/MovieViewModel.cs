using System;
using System.ComponentModel;
using TheMovies.MVVM.Models;
using TheMovies.MVVM.ViewModels.Persistence;

namespace TheMovies.MVVM.ViewModels
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        private Movie source;

        private string _title;
        public string Title
        {
            get { return _title; }

            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        private string _genre;
        public string Genre
        {
            get { return _genre; }

            set
            {
                _genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }
        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get { return _duration; }

            set
            {
                _duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }
        private string _instructor;
        public string Instructor
        {
            get { return _instructor; }

            set
            {
                _instructor = value;
                OnPropertyChanged(nameof(Instructor));
            }
        }
        private string _premiereDate;
        public string PremiereDate
        {
            get { return _premiereDate; }

            set
            {
                _premiereDate = value;
                OnPropertyChanged(nameof(PremiereDate));
            }
        }

        #region OnChanged events
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;

            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public MovieViewModel(Movie source)
        {
            this.source = source;

            Title = source.Title;
            Genre = new(source.Genres);
            Duration = source.Duration;
            Instructor = source.Instructor;
            PremiereDate = source.PremiereDate.ToString();
        }

        public void UpdateSource()
        {
            source.Title = Title;
            source.Genres = Genre;
            source.Duration = Duration;
            source.Instructor = Instructor;
            source.PremiereDate = DateOnly.Parse(PremiereDate);
        }

        public void Delete()
        {
            MovieRepository.Instance.Delete(source);
        }
    }
}
