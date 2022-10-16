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
