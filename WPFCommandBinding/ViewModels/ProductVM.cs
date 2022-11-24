using WPFCommandBinding.Models;

namespace WPFCommandBinding.ViewModels
{
    public class ProductVM
    {
        private Product source;

        public string Name { get; set; }
        public double Price { get; set; }

        public ProductVM (Product source) {
            this.source = source;

            Name = source.Name;
            Price = source.Price;
        }

        public void DeleteFromRepo () {
            ProductRepository.Instance.Delete(source.ID);
        }
    }
}
