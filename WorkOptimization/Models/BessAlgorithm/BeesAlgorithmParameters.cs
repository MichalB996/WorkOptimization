namespace WorkOptimization.Models.BessAlgorithm
{
    public class BeesAlgorithmParameters
    {
        private int _employeesNumber;
        private int _sizeOfPopulation;
        private int _numberOfIterations;
        private double _numberOfEliteBees;
        private double _numberOfAcceptableBees;

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
            }
        }

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
