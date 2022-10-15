using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
