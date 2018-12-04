using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.Models.BessAlgorithm;
using WorkOptimization.Models.FactoryProcessing;
using WorkOptimization.ViewModels.Commands;

namespace WorkOptimization.ViewModels
{
    public class BeeAlgorithmViewModel
    {
        public CreateBeeCommand CreateBeeCommand { get; set; }
        public BeesAlgorithmParameters BAParameters { get; set; }
        public BeeAlgorithmViewModel()
        {
            this.BAParameters = new BeesAlgorithmParameters();
            this.CreateBeeCommand = new CreateBeeCommand(this);
        }
        public void CreateMethod()
        {
            //Debug.WriteLine("hello");
            FactoryController Factory = FactoryController.Create();
            BAParameters.EmployeesNumber = 25;
            //GeneticAlgorithmParameters newParameters = GeneticAlgorithmParameters.Create(this.Parameters.EmployeesNumber, this.Parameters.SizeOfPopulation, this.Parameters.NumberOfIterations, this.Parameters.MutationRate, this.Parameters.PercentageOfChildrenFromPreviousGeneration, 0);
            BeesAlgorithmController Controller = new BeesAlgorithmController(BAParameters, Factory);

        }
    }
}
