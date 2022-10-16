using System.ComponentModel;
using WpfApplication.ViewModels;

namespace WpfApplication.Commands
{
    internal class UseCreditCommand : CommandBase
    {
        private readonly CartViewModel _viewModel;

        public UseCreditCommand(CartViewModel viewModel)
        {
            _viewModel = viewModel;

            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.IsCreditUsed))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object parameter)
        {
            _viewModel.Cart.CreditUsed = _viewModel.Cart.Customer.Credit;
            _viewModel.Cart.TotalAmount -= _viewModel.Cart.CreditUsed;
            _viewModel.IsCreditUsed = true;
        }

        public override bool CanExecute(object parameter)
        {
            return !_viewModel.IsCreditUsed;
        }
    }
}
