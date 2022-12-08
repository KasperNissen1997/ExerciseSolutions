using System;

namespace ExerciseProject.Exercise34
{
    public class Student : Person, IObserver
    {
        public string Message { get; set; }

        public Student(string name) : base(name) { }

        #region Interface IObserver
        public void Update(object sender, EventArgs e)
        {
            if (sender is Academy academy)
            {
                Message = academy.Message;
                Console.WriteLine($"Studerende {Name} modtog nyheden {Message} fra akademiet {academy.Name}");
            }
            else
            {
                throw new ArgumentException("\"sender\" couldn't be casted to an Academy class?");
            }
        }
        #endregion
    }
}
