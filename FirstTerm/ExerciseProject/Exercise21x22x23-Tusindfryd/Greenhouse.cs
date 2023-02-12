namespace ExerciseProject.Exercise21_Tusindfryd
{
    public class Greenhouse
    {
        public string Name { get; private set; }

        public List<ProductionTray> ProductionTrays { get; set; }

        public Greenhouse (string name) {
            Name = name;

            ProductionTrays = new List<ProductionTray>();
        }
    }
}
