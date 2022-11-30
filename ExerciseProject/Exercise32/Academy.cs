namespace ExerciseProject.Exercise32
{
    public class Academy : Organization, ISubject
    {
        private List<IObserver> students;

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
                Notify();
            }
        }

        public Academy(string name, string address) : base(name)
        {
            students = new List<IObserver>();

            Address = address;
        }

        #region Interface ISubject
        public void Attach(IObserver o)
        {
            students.Add(o);
        }

        public void Detach(IObserver o)
        {
            students.Remove(o);
        }

        public void Notify()
        {
            foreach (IObserver student in students)
            {
                student.Update();
            }
        }
        #endregion
    }
}
