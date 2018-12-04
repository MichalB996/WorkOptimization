using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.Models.BessAlgorithm;
using WorkOptimization.Models.FactoryProcessing;
using WorkOptimization.Models.GeneticAlgorithm;
using WorkOptimization.Models.Plotter;
using WorkOptimization.ViewModels.Commands;
using System.Collections.ObjectModel;
namespace WorkOptimization.ViewModels
{
    public class BothAlgorithmsViewModel
    {
        public CreateGACommand CreateGACommand { get; set; }
        public CreateBACommand CreateBACommand { get; set; }
        public GeneticAlgorithmParameters GAParameters { get; set; }
        public BeesAlgorithmParameters BAParameters { get; set; }

        public BothAlgorithmsViewModel()
        {
            this.GAParameters = new GeneticAlgorithmParameters();
            this.BAParameters = new BeesAlgorithmParameters();
            this.CreateGACommand = new CreateGACommand(new GeneticAlgorithmViewModel(GAParameters));
            this.CreateBACommand = new CreateBACommand(new BeeAlgorithmViewModel(BAParameters));
        }
    }
}
