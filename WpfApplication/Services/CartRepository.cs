using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Models;

namespace WpfApplication.Services
{
    internal class CartRepository : ICartRepository
    {
        private static Cart _cart = new Cart();

        public bool AddProductToCart(Product product)
        {
            _cart.Products.Add(product);
            return true;
        }

        public bool ClearCart()
        {
            _cart = new Cart();
            return true;
        }

        public Cart GetCart()
        {
            return _cart;
        }

        public List<Product> GetProducts()
        {
            return _cart.Products.ToList();
        }

        public float GetProductsAmount()
        {
            float amount = 0;
            foreach (var item in _cart.Products)
            {
                amount += item.Price;
            }
            return amount;
        }

        public bool RemoveProduct(Product product)
        {
            _cart.Products.Remove(product);
            return true;
        }

        public bool UpdateCart(Cart cart)
        {
            _cart = cart;
            return true;
        }
    }
}
