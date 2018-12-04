﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.Models.FactoryProcessing;
using WorkOptimization.Models.GeneticAlgorithm;
using WorkOptimization.ViewModels.Commands;

namespace WorkOptimization.ViewModels
{
    public class GeneticAlgorithmViewModel
    {
        public CreateGACommand CreateGACommand { get; set; }
        public GeneticAlgorithmParameters Parameters { get; set; }
        public GeneticAlgorithmViewModel()
        {
            this.Parameters = new GeneticAlgorithmParameters();
            this.CreateGACommand = new CreateGACommand(this);
        }
        public void CreateMethod()
        {
            //Debug.WriteLine("hello");
            FactoryController Factory = FactoryController.Create();
            Parameters.EmployeesNumber = 25;
            Parameters.PercentageOfParentsChosenToSelection = 0;
            //GeneticAlgorithmParameters newParameters = GeneticAlgorithmParameters.Create(this.Parameters.EmployeesNumber, this.Parameters.SizeOfPopulation, this.Parameters.NumberOfIterations, this.Parameters.MutationRate, this.Parameters.PercentageOfChildrenFromPreviousGeneration, 0);
            GeneticAlgorithmController Controller = new GeneticAlgorithmController(Parameters, Factory);

        }
    }
}
