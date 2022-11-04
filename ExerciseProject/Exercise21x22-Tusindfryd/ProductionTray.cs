namespace ExerciseProject.Exercise21_Tusindfryd
{
    public class ProductionTray
    {
        public string Name { get; set; }
        public double Capacity { get; set; }

        public ProductionTray (string name, double capacity) {
            Name = name;
            Capacity = capacity;
        }
    }
}
