using System;
using System.ComponentModel;
using System.Globalization;
using TheMoviesSQL.MVVM.Models;
using TheMoviesSQL.MVVM.ViewModels.Persistence;

namespace TheMoviesSQL.MVVM.ViewModels
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
        private string _premiereDateTime;
        public string PremiereDateTime
        {
            get { return _premiereDateTime; }

            set
            {
                _premiereDateTime = value;
                OnPropertyChanged(nameof(PremiereDateTime));
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
            Genre = new(source.Genre);
            Duration = source.Duration;
            Instructor = source.Instructor;
            PremiereDateTime = source.PremiereDateTime.ToString("yyyy-MM-dd");
        }

        public void UpdateSource()
        {
            source.Title = Title;
            source.Genre = Genre;
            source.Duration = Duration;
            source.Instructor = Instructor;
            source.PremiereDateTime = DateTime.ParseExact(PremiereDateTime, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            MovieRepository.Instance.Update(source);
        }

        public void Delete()
        {
            MovieRepository.Instance.Delete(source);
        }
    }
}
