using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Models;
using WpfApplication.Services;
using WpfApplication.Stores;

namespace WpfApplication.ViewModels
{
    internal class AddProductViewModel : ViewModelBase
    {
        private readonly IProductRepository _repository;

        public AddProductViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _repository = new ProductRepository();
            AddProductCommand = new AddProductCommand(_repository);
            Product = new Product();
        }

        public IEnumerable<Category> ProductTypes
        {
            get
            {
                return Enum.GetValues(typeof(Category)).Cast<Category>();
            }
        }

        private Category _category;

        public Category ProductType
        {
            get { return _category; }
            set
            {
                _category = value;
                Product.Category = _category;
                OnPropertyChanged(nameof(Category));
            }
        }


        private Product _product;

        public Product Product
        {
            get { return _product; }
            set { _product = value; OnPropertyChanged(nameof(Product)); }
        }

        public ICommand AddProductCommand { get; }
    }
}
