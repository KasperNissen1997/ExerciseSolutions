namespace ExerciseProject.Exercise33
{
    public class Order
    {
        private List<Product> products;

        public BonusProvider Bonus { get; set; }

        public Order()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product p)
        {
            products.Add(p);
        }

        public double GetValueOfProducts()
        {
            double sum = 0;

            foreach (Product p in products)
                sum += p.Value;

            return sum;
        }

        public double GetBonus()
        {
            return Bonus(GetValueOfProducts());
        }

        public double GetTotalPrice()
        {
            return GetValueOfProducts() - GetBonus();
        }
    }
}
