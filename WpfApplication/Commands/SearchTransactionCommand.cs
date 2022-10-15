using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication.Commands
{
    internal class SearchTransactionCommand : CommandBase
    {
        private readonly Action _onSearchTransactionCommand;

        public SearchTransactionCommand(Action onSearchTransactionCommand)
        {
            _onSearchTransactionCommand = onSearchTransactionCommand;
        }

        public override void Execute(object parameter)
        {
            _onSearchTransactionCommand();
        }
    }
}
