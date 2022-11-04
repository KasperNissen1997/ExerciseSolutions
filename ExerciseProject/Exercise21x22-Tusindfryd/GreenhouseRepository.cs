namespace ExerciseProject.Exercise21_Tusindfryd
{
    public class GreenhouseRepository
    {
        List<Greenhouse> greenhouses;

        public GreenhouseRepository () {
            greenhouses = new List<Greenhouse>();
        }

        public void Add (Greenhouse greenhouse) {
            greenhouses.Add(greenhouse);
        }

        public Greenhouse Get (string name) {
            foreach (Greenhouse greenhouse in greenhouses) { 
                if (greenhouse.Name == name)
                    return greenhouse;
            }

            return null;
        }

        public void Remove (Greenhouse greenhouse) {
            greenhouses.Remove(greenhouse);
        }
    }
}
