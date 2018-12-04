using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.Models.FactoryProcessing;
using WorkOptimization.Models.GeneticAlgorithm;
using WorkOptimization.Models.Plotter;
using WorkOptimization.ViewModels.Commands;

namespace WorkOptimization.ViewModels
{
    public class GeneticAlgorithmViewModel
    {
        public CreateGACommand CreateGACommand { get; set; }
        public GeneticAlgorithmParameters Parameters { get; set; }
        public Collection<CollectionDataValue> Data { get; set; }

        public GeneticAlgorithmViewModel()
        {
            this.Parameters = new GeneticAlgorithmParameters();
            this.CreateGACommand = new CreateGACommand(this);
        }
        public GeneticAlgorithmViewModel(GeneticAlgorithmParameters gap)
        {
            this.Parameters = gap;
            this.CreateGACommand = new CreateGACommand(this);
        }

        public GeneticAlgorithmViewModel(Collection<CollectionDataValue> Data)
        {
            this.Data = Data;
        }

        public void CreateMethod()
        {
            FactoryController Factory = FactoryController.Create();
            Parameters.EmployeesNumber = 25;
            Parameters.PercentageOfParentsChosenToSelection = 0;                                                                     
            GeneticAlgorithmController Controller = new GeneticAlgorithmController(Parameters, Factory);
            Data = Plotter.Plot(Controller._iterationResults);
        }
    }
}
