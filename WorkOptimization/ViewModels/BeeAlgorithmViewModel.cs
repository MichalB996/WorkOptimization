using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.Models.BessAlgorithm;
using WorkOptimization.Models.FactoryProcessing;
using WorkOptimization.Models.Plotter;
using WorkOptimization.ViewModels.Commands;

namespace WorkOptimization.ViewModels
{
    public class BeeAlgorithmViewModel
    {
        public CreateBACommand CreateBeeCommand { get; set; }
        public BeesAlgorithmParameters BAParameters { get; set; }
        public Collection<CollectionDataValue> Data { get; set; }

        public BeeAlgorithmViewModel()
        {
            this.BAParameters = new BeesAlgorithmParameters();
            this.CreateBeeCommand = new CreateBACommand(this);
        }

        public BeeAlgorithmViewModel(BeesAlgorithmParameters bap)
        {
            this.BAParameters = bap;
            this.CreateBeeCommand = new CreateBACommand(this);
        }

        public void CreateMethod()
        {
            FactoryController Factory = FactoryController.Create();
            BAParameters.EmployeesNumber = Factory.EmployeesList.Count;
            BeesAlgorithmController Controller = new BeesAlgorithmController(BAParameters, Factory);
            Data = Plotter.Plot(Controller._iterationResults);
        }
    }
}
