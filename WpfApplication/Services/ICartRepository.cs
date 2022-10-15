using System.Collections.Generic;
using WpfApplication.Models;

namespace WpfApplication.Services
{
    interface ICartRepository
    {
        bool AddProductToCart(Product product);
        bool UpdateCart(Cart cart);
        Cart GetCart();
        List<Product> GetProducts();
        bool RemoveProduct(Product product);
        float GetProductsAmount();
        bool ClearCart();
    }
}
