using System;
using ExerciseProject.Exercise31;

namespace ExerciseProject.Exercise32
{
    public class Student : Person, IObserver
    {
        private ISubject academy;

        public string Message { get; set; }

        public Student(ISubject academy, string name) : base(name) 
        {
            this.academy = academy;
        }

        #region Interface IObserver
        public void Update()
        {
            if (academy is Academy tempAcademy)
            {
                Message = tempAcademy.Message;
                Console.WriteLine($"Studerende {Name} modtog nyheden {Message} fra akademiet {tempAcademy.Name}");
            }
            else
            {
                throw new ArgumentException("\"academy\" couldn't be casted to an Academy class?");
            }
        }
        #endregion
    }
}
