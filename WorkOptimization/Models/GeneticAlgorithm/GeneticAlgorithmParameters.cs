using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOptimization.Models.GeneticAlgorithm
{
    public class GeneticAlgorithmParameters
    {
        private int _employeesNumber;
        private int _sizeOfPopulation;
        private int _numberOfIterations;
        private double _mutationRate;
        private double _percentageOfChildrenFromPreviousGeneration;
        private double _percentageOfParentsChosenToSelection;

        public int EmployeesNumber
        {
            get
            {
                return _employeesNumber;
            }

            set
            {
                if (_employeesNumber == value)
                {
                    return;
                }

                _employeesNumber = value;
            }
        }

        public int SizeOfPopulation
        {
            get
            {
                return _sizeOfPopulation;
            }

            set
            {
                if (_sizeOfPopulation == value)
                {
                    return;
                }

                _sizeOfPopulation = value;
            }
        }

        public int NumberOfIterations
        {
            get
            {
                return _numberOfIterations;
            }

            set
            {
                if (_numberOfIterations == value)
                {
                    return;
                }

                _numberOfIterations = value;
            }
        }

        public double MutationRate
        {
            get
            {
                return _mutationRate;
            }

            set
            {
                if (_mutationRate == value)
                {
                    return;
                }

                _mutationRate = value;
            }
        }

        
        public double PercentageOfChildrenFromPreviousGeneration
        {
            get
            {
                return _percentageOfChildrenFromPreviousGeneration;
            }

            set
            {
                if (_percentageOfChildrenFromPreviousGeneration == value)
                {
                    return;
                }

                _percentageOfChildrenFromPreviousGeneration = value;
            }
        }

        
        public double PercentageOfParentsChosenToSelection
        {
            get
            {
                return _percentageOfParentsChosenToSelection;
            }

            set
            {
                if (_percentageOfParentsChosenToSelection == value)
                {
                    return;
                }

                _percentageOfParentsChosenToSelection = value;
            }
        }

        private GeneticAlgorithmParameters(int employeesNumber, int sizeOfPopulation, int numberOfIterations, 
            double mutationRate, double percentageOfChildrenFromPreviousGeneration, double percentageOfParentsChosenToSelection)
        {
            EmployeesNumber = employeesNumber;
            SizeOfPopulation = sizeOfPopulation;
            NumberOfIterations = numberOfIterations;
            MutationRate = mutationRate;
            PercentageOfChildrenFromPreviousGeneration = percentageOfChildrenFromPreviousGeneration;
            PercentageOfParentsChosenToSelection = PercentageOfParentsChosenToSelection;
        }

        public static GeneticAlgorithmParameters Create(int employeesNumber, int sizeOfPopulation, int numberOfIterations,
            double mutationRate, double percentageOfChildrenFromPreviousGeneration, double percentageOfParentsChosenToSelection)
            => new GeneticAlgorithmParameters(employeesNumber, sizeOfPopulation, numberOfIterations,
                                    mutationRate, percentageOfChildrenFromPreviousGeneration, percentageOfParentsChosenToSelection);
    }
}
