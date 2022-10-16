using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Services;
using WpfApplication.State;

namespace WpfApplication.ViewModels.Factories
{
    internal class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private readonly IViewModelFactory<ProductListViewModel> _productListViewModelFactory;
        private readonly IViewModelFactory<CustomerListViewModel> _customerListViewModelFactory;
        private readonly IViewModelFactory<TransactionViewModel> _transactionViewModelFactory;
        private readonly IViewModelFactory<SearchTransactionViewModel> _searchTransactionViewModelFactory;
        private readonly IViewModelFactory<AddProductViewModel> _addProductViewModelFactory;
        private readonly IViewModelFactory<CustomerRegistrationViewModel> _registerCustomerViewModelFactory;
        private readonly IViewModelFactory<CartViewModel> _cartViewModelFactory;

        public ViewModelAbstractFactory(IViewModelFactory<ProductListViewModel> productListViewModelFactory, 
            IViewModelFactory<CustomerListViewModel> customerListViewModelFactory, 
            IViewModelFactory<TransactionViewModel> transactionViewModelFactory, 
            IViewModelFactory<SearchTransactionViewModel> searchTransactionViewModelFactory, 
            IViewModelFactory<AddProductViewModel> addProductViewModelFactory, 
            IViewModelFactory<CustomerRegistrationViewModel> registerCustomerViewModelFactory, 
            IViewModelFactory<CartViewModel> cartViewModelFactory)
        {
            _productListViewModelFactory = productListViewModelFactory;
            _customerListViewModelFactory = customerListViewModelFactory;
            _transactionViewModelFactory = transactionViewModelFactory;
            _searchTransactionViewModelFactory = searchTransactionViewModelFactory;
            _addProductViewModelFactory = addProductViewModelFactory;
            _registerCustomerViewModelFactory = registerCustomerViewModelFactory;
            _cartViewModelFactory = cartViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _productListViewModelFactory.CreateViewModel();
                case ViewType.Cart:
                    return _cartViewModelFactory.CreateViewModel();
                case ViewType.Transaction:
                    return _transactionViewModelFactory.CreateViewModel();
                case ViewType.SearchTransaction:
                    return (_searchTransactionViewModelFactory.CreateViewModel());
                case ViewType.Customer:
                    return _customerListViewModelFactory.CreateViewModel();
                case ViewType.RegisterCustomer:
                    return _registerCustomerViewModelFactory.CreateViewModel();
                case ViewType.AddProduct:
                    return _addProductViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("The viewType does not have a ViewModel", "viewType");
            }
        }
    }
}
