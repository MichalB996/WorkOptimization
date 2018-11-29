using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.Models.FactoryProcessing;
using WorkOptimization.Models.MathematicalModel.Subjects;

namespace WorkOptimization.Models.BessAlgorithm
{
    public class BeesAlgorithmController
    {
        public static readonly Random _randomNumber = new Random();
        private int _employeesNumber;
        private int _sizeOfPopulation;
        private int _numberOfIterations;
        private double _numberOfEliteBees;
        private double _numberOfAcceptableBees;
        private FactoryController _factory;
        private Subjects _subjects;
        public List<double> _iterationResults;
        public List<Bee> Population { get; set; }

        public BeesAlgorithmController(BeesAlgorithmParameters algorithmParameteres, FactoryController factory)
        {
            _employeesNumber = algorithmParameteres.EmployeesNumber;
            _sizeOfPopulation = algorithmParameteres.SizeOfPopulation;
            _numberOfIterations = algorithmParameteres.NumberOfIterations;
            _numberOfEliteBees = algorithmParameteres.NumberOfEliteBees;
            _numberOfAcceptableBees = algorithmParameteres.NumberOfAcceptableBees;
            _factory = factory;
            _subjects = new Subjects(factory);
            _subjects.MakeSubject();
            _iterationResults = new List<double>();

            Population = new List<Bee>();
            CreatePopulation(_sizeOfPopulation, _employeesNumber, _subjects);
        }
    }
}
