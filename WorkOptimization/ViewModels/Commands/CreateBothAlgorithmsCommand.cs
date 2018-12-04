using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WorkOptimization.ViewModels.Commands
{
    public class CreateBothAlgorithmsCommand : ICommand
    {
        public BothAlgorithmsViewModel BothAlgorithms { get; set; }
        public event EventHandler CanExecuteChanged;

        public CreateBothAlgorithmsCommand(BothAlgorithmsViewModel x)
        {
            this.BothAlgorithms = x;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {}
    }
}
