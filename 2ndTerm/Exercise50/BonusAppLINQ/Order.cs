using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BonusAppLINQ
{
    public class Order
    {
        public BonusProvider Bonus { get; set; }
        private List<Product> _products = new List<Product>();

        public void AddProduct(Product p)
        {
            _products.Add(p);
        }

        public double GetValueOfProducts()
        {
            return _products.Sum(p => p.Value);
        }

        public double GetValueOfProducts(DateTime date)
        {
            return _products
                .Where(p => (date <= p.AvailableTo && date >= p.AvailableFrom))
                .Sum(p => p.Value);
        }

        public double GetValueOfProductsWithoutWhere(DateTime date)
        {
            return _products
                .Sum(p => (date <= p.AvailableTo && date >= p.AvailableFrom) ? p.Value : 0);
        }

        public double GetBonus()
        {
            return Bonus(GetValueOfProducts());
        }

        public double GetBonus(Func<double, double> bonus)
        {
            return bonus(GetValueOfProducts());
        }

        public double GetBonus(DateTime date, Func<double, double> bonus)
        {
            return bonus(GetValueOfProducts(date));
        }

        public double GetTotalPrice()
        {
            return GetValueOfProducts() - GetBonus();
        }

        public double GetTotalPrice(Func<double, double> bonus)
        {
            return GetValueOfProducts() - GetBonus(bonus);
        }

        public double GetTotalPrice(DateTime date, Func<double, double> bonus)
        {
            return GetValueOfProducts(date) - GetBonus(date, bonus);
        }

        public List<Product> SortProductOrderByAvailableTo()
        {
            return _products.OrderBy(p => p.AvailableTo).ToList();
        }

        public List<Product> SortProductOrderBy(Func<Product, object> keySelector)
        {
            return _products.OrderBy(keySelector).ToList();
        }
    }
}
