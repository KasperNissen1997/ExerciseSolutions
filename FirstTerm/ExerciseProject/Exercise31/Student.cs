namespace ExerciseProject.Exercise31
{
    public class Student : Observer
    {
        private Academy subject;

        public string Name { get; }
        public string Message { get; set; }

        public Student (Academy subject, string name) {
            this.subject = subject;
            Name = name;
        }

        public override void Update () {
            Message = subject.Message;

            // proclaim to the wooorld
            Console.WriteLine($"Studerende {Name} modtog nyheden {Message} fra akademiet {subject.Name}");
        }
    }
}
