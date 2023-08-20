namespace WPFCommandBinding.Models
{
    public class Product
    {
        private static int iDCount = 0;

        public int ID { get; }

        public string Name { get; set; }
        public double Price { get; set; }

        public Product (string name, double price) {
            ID = iDCount++;

            Name = name;
            Price = price;
        }
    }
}
