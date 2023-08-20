namespace ExerciseProject.Exercise21_Tusindfryd
{
    public class FlowerTypeRepository
    {
        List<FlowerType> flowerTypes;

        public FlowerTypeRepository () {
            flowerTypes = new List<FlowerType>();
        }

        public void Add (FlowerType flowerType) {
            flowerTypes.Add(flowerType);
        }

        public FlowerType Get (string name) {
            foreach (FlowerType flowerType in flowerTypes) {
                if (flowerType.Name.Equals(name))
                    return flowerType;
            }

            return null;
        }

        public void Remove (FlowerType flowerType) {
            flowerTypes.Remove(flowerType);
        }

        public int Count () {
            return flowerTypes.Count;
        }

        public void Save (string filePath = @"..\..\..\Exercise21x22-Tusindfryd\flowerTypeRepository.txt") {
            throw new NotImplementedException();
        }

        public void Load (string filePath = @"..\..\..\Exercise21x22-Tusindfryd\flowerTypeRepository.txt") {
            throw new NotImplementedException();
        }
    }
}
