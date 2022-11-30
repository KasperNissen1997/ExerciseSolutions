﻿namespace ExerciseProject.Exercise32
{
    public interface ISubject
    {
        public void Attach(IObserver o);
        public void Detach(IObserver o);
        public void Notify();
    }
}
