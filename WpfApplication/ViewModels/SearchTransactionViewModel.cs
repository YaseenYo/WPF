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
    internal class SearchTransactionViewModel : ViewModelBase
    {
        private readonly ITransactionRepository _transactionRepository;
        public SearchTransactionViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _transactionRepository = new TransactionRepository();
            Transaction = new Transaction();
            SearchTransactionCommand = new SearchTransactionCommand(OnSearchTransactionCommand);
        }

        private Guid _transactionId;

        public Guid TransactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; OnPropertyChanged(nameof(TransactionId)); }
        }

        private Transaction _transaction;

        public Transaction Transaction
        {
            get { return _transaction; }
            set { _transaction = value; OnPropertyChanged(nameof(Transaction)); }
        }

        public ICommand SearchTransactionCommand { get; }

        private void OnSearchTransactionCommand()
        {
            Transaction transaction = _transactionRepository.Search(TransactionId);
            if(transaction != null)
            {
                Transaction = transaction;
                return;
            }    
            Transaction = new Transaction();
        }
    }
}
