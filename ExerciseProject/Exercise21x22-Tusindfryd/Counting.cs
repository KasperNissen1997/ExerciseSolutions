namespace ExerciseProject.Exercise21_Tusindfryd
{
    public class Counting
    {
        public int ID { get; private set; }

        public DateOnly Date { get; set; }
        public int Amount { get; set; }
        public int ExpectedAmount { get; set; }
        public double DeviationInPercentage { get; set; }

        public Employee Employee { get; set; }

        public Counting (DateOnly date, int amount, int expectedAmount, Employee employee) {
            Date = date;
            Amount = amount;
            ExpectedAmount = expectedAmount;

            Employee = employee;
        }
    }
}
