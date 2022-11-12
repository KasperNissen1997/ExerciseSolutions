namespace ExerciseProject.Exercise21_Tusindfryd
{
    public class FlowerType
    {
        public string Name { get; set; }
        public int ProductionDays { get; set; }
        public int HalfLifeDays { get; set; }
        public double Size { get; set; }
        public string ImagePath { get; set; }

        public FlowerType (string name, int productionDays, int halfLifeDays, double size, string imagePath) {
            Name = name;
            ProductionDays = productionDays;
            HalfLifeDays = halfLifeDays;
            Size = size;
            ImagePath = imagePath;
        }

        public FlowerType (string name, int productionDays, int halfLifeDays, double size) 
            : this (name, productionDays, halfLifeDays, size, null) { }
    }
}
