namespace ExerciseProject.Exercise15x16x17x18x19
{
    public interface IPersistable
    {
        public void Save ();

        public void Save (string fileName);

        public void Load ();

        public void Load (string fileName);
    }
}
