using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8.Commands
{
    internal class BaseCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public BaseCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _CanExecute = canExecute;
        }

        public override void Execute(object parameter) => _Execute(parameter);
        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;
    }
}
