namespace ExerciseProject.Exercise31
{
    public class ConcreteSubject : Subject
    {
        private int _state = 0;
        public int State {
            get { return _state; }
            set {
                _state = value;
                Notify();
            }
        }
    }
}
