namespace ExerciseProject.Exercise21_Tusindfryd
{
    public class Controller
    {
        public FlowerTypeRepository flowerTypeRepo;

        public Controller () {
            flowerTypeRepo = new FlowerTypeRepository();
        }

        public void RegisterNewFlowerType (string name, string imagePath, int productionDays, int halfLifeDays, double size) {
            FlowerType newFlowerType = new FlowerType(name, productionDays, halfLifeDays, size, imagePath);

            flowerTypeRepo.Add(newFlowerType);
        }
    }
}
