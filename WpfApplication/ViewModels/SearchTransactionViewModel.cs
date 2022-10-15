using System;
using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Models;
using WpfApplication.Stores;

namespace WpfApplication.ViewModels
{
    internal class SearchTransactionViewModel : ViewModelBase
    {
        public SearchTransactionViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            Transaction = new Transaction();
            SearchTransactionCommand = new SearchTransactionCommand(this);
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
    }
}
