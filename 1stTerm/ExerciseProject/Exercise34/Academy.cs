using System.ComponentModel;

namespace ExerciseProject.Exercise34
{
    public class Academy : Organization, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }

            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public Academy(string name, string address) : base(name)
        {
            Address = address;
        }
        
        public void OnPropertyChanged()
        {
            PropertyChanged(this, null);
        }
    }
}
