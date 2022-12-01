namespace ExerciseProject.Exercise33
{
    public class Academy : Organization
    {
        public NotifyHandler MessageChanged;

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
                MessageChanged();
            }
        }

        public Academy(string name, string address) : base(name)
        {
            Address = address;
        }
        
        public void OnMessageChanged()
        {
            //students();
        }
    }
}
