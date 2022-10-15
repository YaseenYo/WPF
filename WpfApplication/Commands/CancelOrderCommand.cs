using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication.Commands
{
    internal class CancelOrderCommand : CommandBase
    {
        private Action _onCancel;

        public CancelOrderCommand(Action onCancel)
        {
            _onCancel = onCancel;
        }

        public override void Execute(object parameter)
        {
            _onCancel();
        }
    }
}
