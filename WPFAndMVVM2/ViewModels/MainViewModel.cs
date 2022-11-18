using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PersonRepository personRepo = new PersonRepository();

        // Implement the rest of this MainViewModel class below to 
        // establish the foundation for data binding !

        public ObservableCollection<PersonViewModel> PersonsVM { get; set; }

        private PersonViewModel _selectedPerson; 
        public PersonViewModel SelectedPerson {
            get { 
                return _selectedPerson; 
            } 
            set { 
                _selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            } 
        }

        public MainViewModel () {
            PersonsVM = new ObservableCollection<PersonViewModel>();

            foreach (Person person in personRepo.GetAll()) {
                PersonsVM.Add(new PersonViewModel(person));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged (string propertyName) {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;

            if (propertyChanged != null) {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void AddDefaultPerson () {
            Person person = personRepo.Add("Specify FirstName", "Specify LastName", 0, "Specify Phone");
            PersonViewModel personVM = new PersonViewModel(person);
            
            PersonsVM.Add(personVM);
            SelectedPerson = personVM;
        }

        public void DeleteSelectedPerson () {
            SelectedPerson.DeletePerson(personRepo);
            PersonsVM.Remove(SelectedPerson);
        }
    }
}
