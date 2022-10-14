namespace ExerciseProject.Exercise15x16x17x18x19
{
    public class ValuableRepository
    {
        List<IValuable> valuables = new List<IValuable>();

        public void AddValuable (IValuable valuable) {
            valuables.Add(valuable);
        }

        public IValuable GetValuable (string id) {
            foreach (IValuable valuable in valuables) {
                if (valuable is Amulet amulet)
                    if (amulet.ItemId == id)
                        return amulet;

                if (valuable is Book book)
                    if (book.ItemId == id)
                        return book;

                if (valuable is Course course)
                    if (course.Name == id)
                        return course;
            }

            return null;
        }

        public double GetTotalValue () {
            double totalValue = 0;

            foreach (IValuable valuable in valuables) {
                totalValue += valuable.GetValue();
            }

            return totalValue;
        }

        public int Count () {
            return valuables.Count;
        }
    }
}
