using System;
using System.Windows.Input;
using WorkOptimization.Views;

namespace WorkOptimization.ViewModels.Commands
{
    public class CreateBACommand : ICommand
    {
        public BeeAlgorithmViewModel BeeAlgorithm { get; set; }
        public event EventHandler CanExecuteChanged;

        public CreateBACommand(BeeAlgorithmViewModel x)
        {
            this.BeeAlgorithm = x;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.BeeAlgorithm.CreateMethod();
            PlotWindow x = new PlotWindow
            {
                DataContext = this.BeeAlgorithm
            };
            x.Show();
        }
    }
}
