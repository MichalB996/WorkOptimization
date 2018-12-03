using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOptimization.Models.GeneticAlgorithm
{
    public class GeneticAlgorithmParameters : INotifyPropertyChanged
    {
        private int _employeesNumber;
        private int _sizeOfPopulation;
        private int _numberOfIterations;
        private double _mutationRate;
        private double _percentageOfChildrenFromPreviousGeneration;
        private double _percentageOfParentsChosenToSelection;

        public event PropertyChangedEventHandler PropertyChanged;

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
                PropertyChanged(this, new PropertyChangedEventArgs(EmployeesNumber.ToString()));

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
                PropertyChanged(this, new PropertyChangedEventArgs(SizeOfPopulation.ToString()));
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
                PropertyChanged(this, new PropertyChangedEventArgs(NumberOfIterations.ToString()));
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
                PropertyChanged(this, new PropertyChangedEventArgs(MutationRate.ToString()));
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
                PropertyChanged(this, new PropertyChangedEventArgs(PercentageOfChildrenFromPreviousGeneration.ToString()));
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

        public GeneticAlgorithmParameters()
        { }
        public GeneticAlgorithmParameters(GeneticAlgorithmParameters x)
        {
            this.NumberOfIterations = x.NumberOfIterations;
            this.SizeOfPopulation = x.SizeOfPopulation;
            this.MutationRate = x.MutationRate;
            this.PercentageOfChildrenFromPreviousGeneration = x.PercentageOfChildrenFromPreviousGeneration;
            this.EmployeesNumber = 25;
            this.PercentageOfParentsChosenToSelection = 0;

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
