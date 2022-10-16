using System;
using System.ComponentModel;
using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.ViewModels;
using WpfApplication.ViewModels.Factories;

namespace WpfApplication.State
{
    internal class Navigator : INavigator, INotifyPropertyChanged
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set 
            { 
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public ICommand UpdateCurrentViewModelCommand { get; set; } 

        public event PropertyChangedEventHandler PropertyChanged;
        
        public Navigator(IViewModelAbstractFactory viewModelAbstractFactory)
        {
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this, viewModelAbstractFactory);
        }
    }
}
