namespace ExerciseProject.Exercise15x16x17x18
{
    public class AmuletRepository
    {
        List<Amulet> amulets = new List<Amulet>();

        public void AddAmulet (Amulet amulet) {
            amulets.Add(amulet);
        }

        public Amulet GetAmulet (string itemId) {
            foreach (Amulet amulet in amulets) {
                if (amulet.ItemId == itemId) {
                    return amulet;
                }
            }

            return null;
        }

        public double GetTotalValue () {
            Utility util = new Utility();

            double totalValue = 0;

            foreach (Amulet amulet in amulets) {
                totalValue += util.GetValueOfAmulet(amulet);
            }

            return totalValue;
        }
    }
}
