using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Services;

namespace WpfApplication.ViewModels.Factories
{
    internal class SearchTransactionViewModelFactory : IViewModelFactory<SearchTransactionViewModel>
    {
        private readonly ITransactionRepository _transactionRepository;

        public SearchTransactionViewModelFactory(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public SearchTransactionViewModel CreateViewModel()
        {
            return new SearchTransactionViewModel(_transactionRepository);
        }
    }
}
