namespace ExerciseProject.Exercise21_Tusindfryd
{
    public class CountingRepository
    {
        List<Counting> countings;

        public CountingRepository () {
            countings = new List<Counting>();
        }

        public void Add (Counting counting) {
            countings.Add(counting);
        } 

        public Counting Get (int ID) {
            foreach (Counting counting in countings) {
                if (counting.ID == ID)
                    return counting;
            }

            return null;
        }

        public void Remove (Counting counting) {
            countings.Remove(counting);
        }
    }
}
