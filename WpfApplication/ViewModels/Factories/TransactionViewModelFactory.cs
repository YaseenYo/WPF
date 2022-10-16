using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Services;

namespace WpfApplication.ViewModels.Factories
{
    internal class TransactionViewModelFactory : IViewModelFactory<TransactionViewModel>
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionViewModelFactory(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public TransactionViewModel CreateViewModel()
        {
            return new TransactionViewModel(_transactionRepository);
        }
    }
}
