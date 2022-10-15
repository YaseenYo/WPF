using System;
using System.Collections.Generic;
using WpfApplication.Models;

namespace WpfApplication.Services
{
    interface IProductRepository
    {
        List<Product> GetAll();
        bool Add(Product product);
        Product Search(Guid id);
    }
}
