using System;
using System.Collections.Generic;

namespace WPFCommandBinding.Models
{
    /// <summary>
    /// Dummy-repository that doesn't have any Save or Load functionality!
    /// </summary>
    public class ProductRepository
    {
        private List<Product> products { get; }

        #region Singleton
        private static ProductRepository _instance;
        public static ProductRepository Instance {
            get {
                if (_instance == null) {
                    _instance = new ProductRepository();
                    return _instance;
                }

                return _instance;
            }

            private set {
                _instance = value;
            }
        }
        
        private ProductRepository () {
            products = new List<Product>() {
                new Product("Apple", 7.95),
                new Product("Orange", 5.5),
                new Product("Banana", 8.25)
            };
        }
        #endregion

        #region CRUD
        public Product Create (string name, double price) {
            Product product = new Product(name, price);

            products.Add(product);

            return product;
        }

        public Product Retrieve (int id) {
            foreach (Product product in products) {
                if (product.ID == id)
                    return product;
            }

            throw new ArgumentException("No product with id " + id + " exists.");
        }

        public List<Product> RetrieveAll () {
            return products;
        }

        public void Delete (int id) {
            Product product = Retrieve(id);

            products.Remove(product);
        }
        #endregion
    }
}
