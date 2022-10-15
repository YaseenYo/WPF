using System;
using System.Windows;
using WpfApplication.Models;
using WpfApplication.Services;

namespace WpfApplication.Commands
{
    internal class AddProductCommand : CommandBase
    {
        private IProductRepository _productRepository;

        public AddProductCommand()
        {
            _productRepository = new ProductRepository();
        }

        public override void Execute(object parameter)
        {
            Product product = parameter as Product;
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
