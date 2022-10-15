using System.Collections.ObjectModel;
using WpfApplication.Models;
using WpfApplication.Services;
using WpfApplication.Stores;

namespace WpfApplication.ViewModels
{
    internal class CustomerListViewModel : ViewModelBase
    {
		private readonly ICustomersRepository _repository;

        public CustomerListViewModel(NavigationStore navigationStore) : base(navigationStore)
		{
			_repository = new CustomersRepository();
            LoadData();
		} 
        
		private ObservableCollection<Customer> _customers;

        public ObservableCollection<Customer> Customers
		{
			get { return _customers; }
			set { _customers = value; OnPropertyChanged(nameof(Customers)); }
		}

		private void LoadData()
		{
            _customers = new ObservableCollection<Customer>(_repository.GetAll());
        }
	}
}
