namespace ExerciseFlowLib
{
    public static class ExerciseFlow
    {
        public static void FinishTask () {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Task completed! Press enter to continue...");
            Console.ResetColor();
            Console.ReadLine();
            Console.WriteLine();
        }

        public static void FinishExercise (string exerciseName) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("All tasks in " + exerciseName + " completed! Press enter to continue...");
            Console.ResetColor();
            Console.ReadLine();
            Console.WriteLine();
        }

        public static void EndProgram () {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("All activated exercises completed! Press enter to end the program...");
            Console.ResetColor();
            Console.ReadLine();
            Console.WriteLine();
        }
    }
}