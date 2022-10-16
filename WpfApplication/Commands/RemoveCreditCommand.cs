using System;
using System.ComponentModel;
using WpfApplication.Models;
using WpfApplication.ViewModels;

namespace WpfApplication.Commands
{
    internal class RemoveCreditCommand : CommandBase
    {
        private readonly CartViewModel _viewModel;

        public RemoveCreditCommand(CartViewModel viewModel)
        {
            _viewModel = viewModel;
             
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_viewModel.IsCreditUsed))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object parameter)
        {
            _viewModel.Cart.TotalAmount += _viewModel.Cart.CreditUsed;
            _viewModel.Cart.CreditUsed = 0;
            _viewModel.IsCreditUsed = false;
        }
        
        public override bool CanExecute(object parameter)
        {
            return _viewModel.IsCreditUsed;
        }
    }
}
