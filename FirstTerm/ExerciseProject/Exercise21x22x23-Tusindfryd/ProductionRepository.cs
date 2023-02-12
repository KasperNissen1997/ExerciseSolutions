namespace ExerciseProject.Exercise21_Tusindfryd
{
    public class ProductionRepository
    {
        List<Production> productions;

        public ProductionRepository () {
            productions = new List<Production>();
        }

        public void Add (Production production) {
            productions.Add(production);
        }

        public Production Get (int ID) {
            foreach (Production production in productions) {
                if (production.ID == ID) 
                    return production;
            }

            return null;
        }

        public void Remove (Production production) {
            productions.Remove(production);
        }

        public int Count () {
            return productions.Count;
        }
    }
}
