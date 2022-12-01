namespace ExerciseProject.Exercise33
{
    public class Bonuses
    {
        public static double TenPercent(double amount)
        {
            return amount * 0.1;
        }

        public static double FlatTwoIfAmountMoreThanFive(double amount)
        {
            return (amount > 5) ? 2 : 0;
        }
    }
}
