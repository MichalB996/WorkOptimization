using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOptimization.Models.GeneticAlgorithm
{
    public class GeneticAlgorithmController
    {
        private static readonly Random _randomNumber = new Random();
        private int _employeesNumber;
        private int _sizeOfPopulation;
        private int _numberOfIterations;
        private double _mutationRate;
        private double _percentageOfChildrenFromPreviousGeneration;
        private double _percentageOfParentsChosenToSelection;


        public GeneticAlgorithmController(GeneticAlgorithmParameters algorithmParameteres)
        {
            _employeesNumber = algorithmParameteres.EmployeesNumber;
            _sizeOfPopulation = algorithmParameteres.SizeOfPopulation;
            _numberOfIterations = algorithmParameteres.NumberOfIterations;
            _mutationRate = algorithmParameteres.MutationRate;
            _percentageOfChildrenFromPreviousGeneration = algorithmParameteres.PercentageOfChildrenFromPreviousGeneration;
            _percentageOfParentsChosenToSelection = algorithmParameteres.PercentageOfParentsChosenToSelection;
            
        }
    }
}
