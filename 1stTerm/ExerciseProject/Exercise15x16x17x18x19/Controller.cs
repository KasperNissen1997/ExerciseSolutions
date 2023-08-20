namespace ExerciseProject.Exercise15x16x17x18x19
{
    public class Controller
    {
        public ValuableRepository ValuableRepo { get; set; }

        public Controller () {
            ValuableRepo = new ValuableRepository ();
        }

        public void AddToList (IValuable valuable) {
            ValuableRepo.AddValuable(valuable);
        }
    }
}
