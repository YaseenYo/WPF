using WpfApplication.Models;
using WpfApplication.Services;
using WpfApplication.ViewModels;

namespace WpfApplication.Commands
{
    internal class SearchTransactionCommand : CommandBase
    {
        private readonly SearchTransactionViewModel _viewModel;
        private readonly ITransactionRepository _transactionRepository;

        public SearchTransactionCommand(SearchTransactionViewModel viewModel)
        {
            _viewModel = viewModel;
            _transactionRepository = new TransactionRepository();
        }

        public override void Execute(object parameter)
        {
            Transaction transaction = _transactionRepository.Search(_viewModel.TransactionId);
            if (transaction != null)
            {
                _viewModel.Transaction = transaction;
                return;
            }
            _viewModel.Transaction = new Transaction();
        }
    }
}
