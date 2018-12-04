using System.ComponentModel;

namespace WorkOptimization.Models.BessAlgorithm
{
    public class BeesAlgorithmParameters : INotifyPropertyChanged
    {
        private int _employeesNumber;
        private int _sizeOfPopulation;
        private int _numberOfIterations;
        private double _numberOfEliteBees;
        private double _numberOfAcceptableBees;

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

        public double NumberOfEliteBees
        {
            get
            {
                return _numberOfEliteBees;
            }

            set
            {
                if (_numberOfEliteBees == value)
                {
                    return;
                }

                _numberOfEliteBees = value;
                PropertyChanged(this, new PropertyChangedEventArgs(NumberOfEliteBees.ToString()));
            }
        }


        public double NumberOfAcceptableBees
        {
            get
            {
                return _numberOfAcceptableBees;
            }

            set
            {
                if (_numberOfAcceptableBees == value)
                {
                    return;
                }

                _numberOfAcceptableBees = value;
                PropertyChanged(this, new PropertyChangedEventArgs(NumberOfAcceptableBees.ToString()));
            }
        }
        
        public BeesAlgorithmParameters()
        { }

        private BeesAlgorithmParameters(int employeesNumber, int sizeOfPopulation, int numberOfIterations,
            double numberOfEliteBees, double numberOfAcceptableBees)
        {
            EmployeesNumber = employeesNumber;
            SizeOfPopulation = sizeOfPopulation;
            NumberOfIterations = numberOfIterations;
            NumberOfEliteBees = numberOfEliteBees;
            NumberOfAcceptableBees = numberOfAcceptableBees;
        }

        public static BeesAlgorithmParameters Create(int employeesNumber, int sizeOfPopulation, int numberOfIterations,
            double numberOfEliteBees, double numberOfAcceptableBees)
            => new BeesAlgorithmParameters(employeesNumber, sizeOfPopulation, numberOfIterations,
                                    numberOfEliteBees, numberOfAcceptableBees);

    }
}
