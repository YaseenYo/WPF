using Microsoft.Extensions.Logging;
using System;
using System.Windows;
using WpfApplication.Models;
using WpfApplication.Services;

namespace WpfApplication.Commands
{
    internal class AddProductCommand : CommandBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<AddProductCommand> _logger;

        public AddProductCommand(IProductRepository productRepository, 
            ILogger<AddProductCommand> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
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
            _logger.LogInformation($"Product with Id {product.Id} Added to Catalog");
            MessageBox.Show("Product Added");
        }
    }
}
