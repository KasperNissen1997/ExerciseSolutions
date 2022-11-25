namespace ExerciseProject.Exercise31
{
    public class ConcreteObserver : Observer
    {
        private ConcreteSubject subject;

        public int State { get; set; } = 0;

        public ConcreteObserver (ConcreteSubject subject) {
            this.subject = subject;
        }

        public override void Update () {
            State = subject.State;
        }
    }
}
