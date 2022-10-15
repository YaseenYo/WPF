using System;
using System.Collections.Generic;
using System.Linq;
using WpfApplication.Models;

namespace WpfApplication.Services
{
    internal class ProductRepository : IProductRepository
    {
        private static readonly List<Product> _products;

        static ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "IPhone 13 Pro",
                    Category = Category.Phone,
                    Price = 80000
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Realme Pad x",
                    Category = Category.Tablet,
                    Price = 19000
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cricket Game 2022",
                    Category = Category.Games,
                    Price = 4000
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "GTA",
                    Category = Category.Games,
                    Price = 6000
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Samsung Flip X Pro",
                    Category = Category.Phone,
                    Price = 60000
                },
            };
        }

        public bool Add(Product Product)
        {
            _products.Add(Product);
            return true;
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product Search(Guid id)
        {
            return _products.FirstOrDefault(c => c.Id == id);
        }
    }
}
