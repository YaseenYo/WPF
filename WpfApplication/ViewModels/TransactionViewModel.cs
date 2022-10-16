using System.Collections.ObjectModel;
using WpfApplication.Models;
using WpfApplication.Services;
using WpfApplication.Stores;

namespace WpfApplication.ViewModels
{
    internal class TransactionViewModel : ViewModelBase
    {
		private readonly ITransactionRepository _repository;

        public TransactionViewModel(ITransactionRepository repository) //: base(store,navigator)
		{
			_repository = repository;
			LoadData();
		} 

		private ObservableCollection<Transaction> _transactions;

		public ObservableCollection<Transaction> Transactions
		{
			get { return _transactions; }
			set { _transactions = value; }
		}

		private	void LoadData()
		{
			Transactions = new ObservableCollection<Transaction>(_repository.GetAll());
 		}

	}
}
