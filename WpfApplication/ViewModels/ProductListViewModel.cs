using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Models;
using WpfApplication.Services;
using WpfApplication.State;
using WpfApplication.Stores;

namespace WpfApplication.ViewModels
{
    internal class ProductListViewModel : ViewModelBase
    {
        private readonly IProductRepository _productRepository;

        public ProductListViewModel(IProductRepository productRepository, ICartRepository cartRepository)
        {
            _productRepository = productRepository;

            AddToCartCommand = new AddToCartCommand(cartRepository);

            LoadData(); 
        }

        public INavigator Navigator { get; set; }

        public ICommand AddToCartCommand { get; }

        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged(nameof(_products)); }
        }

        private void LoadData()
        {
            _products = new ObservableCollection<Product>(_productRepository.GetAll());
        }
    }
}
