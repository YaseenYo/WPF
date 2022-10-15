using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication.Models;
using WpfApplication.Services;

namespace WpfApplication.Commands
{
    internal class AddProductCommand : CommandBase
    {
        private IProductRepository _productRepository;

        public AddProductCommand(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override void Execute(object parameter)
        {
            Product product = (Product) parameter;
            if (string.IsNullOrWhiteSpace(product.Name) || product.Price <= 0)
            {
                MessageBox.Show("Fill all the fields");
                return;
            }
            product.Id = Guid.NewGuid();
            _productRepository.Add(product);
            MessageBox.Show("Product Added");
        }
    }
}
