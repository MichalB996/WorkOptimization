using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkOptimization.Views;

namespace WorkOptimization.ViewModels.Commands
{
    public class CreateGACommand : ICommand
    {
        public GeneticAlgorithmViewModel GeneticAlgorithm {get; set;}
        public event EventHandler CanExecuteChanged;

        public CreateGACommand(GeneticAlgorithmViewModel x)
        {
            this.GeneticAlgorithm = x;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.GeneticAlgorithm.CreateMethod();
            PlotWindow x = new PlotWindow
            {
                DataContext = this.GeneticAlgorithm
            };
            x.Show();
        }
    }
}
