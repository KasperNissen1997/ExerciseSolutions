namespace ExerciseProject.Exercise31
{
    public class Academy : Subject
    {
        public string Name { get; }

        private string _message;
        public string Message {
            get { return _message; }
            set { 
                _message = value;
                Notify();
            }
        }

        public Academy (string name) {
            Name = name;
        }
    }
}
