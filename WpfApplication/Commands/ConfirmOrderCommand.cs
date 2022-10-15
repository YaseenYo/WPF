using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication.Commands
{
    internal class ConfirmOrderCommand : CommandBase
    {
        private Action _onConfirm;

        public ConfirmOrderCommand(Action onConfirm)
        {
            _onConfirm = onConfirm;
        }

        public override void Execute(object parameter)
        {
            _onConfirm();
        }
    }
}
