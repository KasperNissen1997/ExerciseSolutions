using System;
using System.ComponentModel;

namespace TheMoviesSQL.MVVM.ViewModels
{
    public class AddMovieViewModel : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get { return _title; }

            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(HasAllRequiredInfo));
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
                OnPropertyChanged(nameof(HasAllRequiredInfo));
            }
        }
        private int _durationHours;
        public int DurationHours
        {
            get { return _durationHours; }

            set
            {
                _durationHours = value;

                OnPropertyChanged(nameof(DurationHours));
                OnPropertyChanged(nameof(HasAllRequiredInfo));
            }
        }
        private int _durationMinutes;
        public int DurationMinutes
        {
            get { return _durationMinutes; }

            set
            {
                _durationMinutes = value;

                OnPropertyChanged(nameof(DurationMinutes));
                OnPropertyChanged(nameof(HasAllRequiredInfo));
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
                OnPropertyChanged(nameof(HasAllRequiredInfo));
            }
        }
        private DateTime _premiereDateTime;
        public DateTime PremiereDateTime
        {
            get { return _premiereDateTime; }

            set
            {
                _premiereDateTime = value;

                OnPropertyChanged(nameof(PremiereDateTime));
                OnPropertyChanged(nameof(HasAllRequiredInfo));
            }
        }

        public bool HasAllRequiredInfo
        {
            get
            {
                if (String.IsNullOrEmpty(Title))
                    return false;

                if (String.IsNullOrEmpty(Genre))
                    return false;

                if (DurationHours < 0 || DurationHours > 60)
                    return false;

                if (DurationMinutes < 0 || DurationMinutes > 60)
                    return false;

                if (String.IsNullOrEmpty(Instructor))
                    return false;

                return true;
            }
        }

        public AddMovieViewModel()
        {
            PremiereDateTime = DateTime.Now;
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
    }
}
