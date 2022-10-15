using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.Commands
{
    internal class RemoveCreditCommand : CommandBase
    {
        private Action _TargetExecuteMethod;
        private Func<bool> _TargetCanExecuteMethod;

        public RemoveCreditCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetCanExecuteMethod = canExecuteMethod;
            _TargetExecuteMethod = executeMethod;
        }

        public override void Execute(object parameter)
        {
            _TargetExecuteMethod();
        }
        
        public override bool CanExecute(object parameter)
        {
            return _TargetCanExecuteMethod();
        }
    }
}
