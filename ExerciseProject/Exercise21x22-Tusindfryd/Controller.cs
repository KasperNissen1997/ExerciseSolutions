namespace ExerciseProject.Exercise21_Tusindfryd
{
    public class Controller
    {
        public ProductionRepository ProductionRepo { get; set; }

        public GreenhouseRepository GreenhouseRepo { get; set; }
        public ProductionTrayRepository ProductionTrayRepo { get; set; }
        public FlowerTypeRepository FlowerTypeRepo { get; set; }

        public Controller () {
            ProductionRepo = new ProductionRepository();

            GreenhouseRepo = new GreenhouseRepository();
            ProductionTrayRepo = new ProductionTrayRepository();
            FlowerTypeRepo = new FlowerTypeRepository();
        }

        public void RegisterNewFlowerType (string name, string imagePath, int productionDays, int halfLifeDays, double size) {
            FlowerType newFlowerType = new FlowerType(name, productionDays, halfLifeDays, size, imagePath);

            FlowerTypeRepo.Add(newFlowerType);
        }

        public int StartProduction (string greenhouseName, string productionTrayName, string flowerTypeName, int startAmount, DateOnly date) {
            Greenhouse greenhouse = GreenhouseRepo.Get(greenhouseName);
            ProductionTray productionTray = ProductionTrayRepo.Get(productionTrayName);
            FlowerType flowerType = FlowerTypeRepo.Get(flowerTypeName);

            Production newProduction = new Production(1, date, startAmount, greenhouse, productionTray, flowerType);

            ProductionRepo.Add(newProduction);

            return newProduction.ExpectedAmount;
        }
    }
}
