using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class PersonViewModel
    {
        private Person person;

        public string FirstName { get; set; }
        public string LastName { get; set; }
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

        public void DeletePerson (PersonRepository personRepo) {
            personRepo.Remove(person.Id);
        }
    }
}
