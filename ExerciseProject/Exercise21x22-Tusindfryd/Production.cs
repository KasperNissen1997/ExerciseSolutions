namespace ExerciseProject.Exercise21_Tusindfryd
{
    public class Production
    {
        public int ID { get; private set; }

        public DateOnly Date { get; set; }
        public int StartAmount { get; set; }
        public int ExpectedAmount { get; private set; }
        public bool Finished { get; set; }

        public Greenhouse Greenhouse { get; set; }
        public ProductionTray ProductionTray { get; set; }
        public FlowerType FlowerType { get; set; }

        public Production (int ID, DateOnly date, int startAmount, Greenhouse greenhouse, ProductionTray productionTray, FlowerType flowerType) {
            this.ID = ID;
            
            Date = date;
            StartAmount = startAmount;
            ExpectedAmount = CalculateExpectedAmount();
            Finished = false;

            Greenhouse = greenhouse;
            ProductionTray = productionTray;
            FlowerType = flowerType;
        }

        int CalculateExpectedAmount () {
            return (int) (StartAmount * 0.88); // return 88% of StartAmount, since I don't know how else to implement this...
        }

        public void Finish () {
            Finished = true;
        }

        public override string ToString () {
            return string.Format("ID: {0}, Date: {1}, StartAmount: {2}, ExpectedAmount: {3}, Finished:  {4}\n" +
                "Greenhouse: {5}, ProductionTray: {6}, FlowerType: {7}",
                ID, Date.ToString(), StartAmount, ExpectedAmount, Finished, Greenhouse.Name, ProductionTray.Name, FlowerType.Name);
        }
    }
}
