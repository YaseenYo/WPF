using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Services;

namespace WpfApplication.ViewModels.Factories
{
    internal class AddProductViewModelFactory : IViewModelFactory<AddProductViewModel>
    {
        private readonly IProductRepository _productRepository;

        public AddProductViewModelFactory(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public AddProductViewModel CreateViewModel()
        {
            return new AddProductViewModel(_productRepository);
        }
    }
}
