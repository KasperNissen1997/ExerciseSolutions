using System.ComponentModel;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person person;

        private string _firstName;
        public string FirstName 
        {
            get {
                return _firstName;
            }
            set {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName 
            {
            get 
            {
                return _lastName;
            } 
            set 
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public int Age { get; set; }
        public string Phone { get; set; }
        public string FullName {
            get {
                return FirstName + " " + LastName;
            }
        }

        public PersonViewModel (Person person) {
            this.person = person;

            FirstName = person.FirstName;
            LastName = person.LastName;
            Age = person.Age;
            Phone = person.Phone;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged (string propertyName) 
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;

            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void DeletePerson (PersonRepository personRepo) {
            personRepo.Remove(person.Id);
        }
    }
}
