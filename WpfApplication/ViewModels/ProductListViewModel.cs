using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Models;
using WpfApplication.Services;
using WpfApplication.Stores;

namespace WpfApplication.ViewModels
{
    internal class ProductListViewModel : ViewModelBase
    {
        private readonly IProductRepository _productRepository;

        public ProductListViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _productRepository = new ProductRepository();

            AddToCartCommand = new AddToCartCommand();

            LoadData();
        }

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
