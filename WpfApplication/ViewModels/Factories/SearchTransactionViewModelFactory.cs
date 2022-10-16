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
