using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.Comparers;
using WorkOptimization.EF;
using WorkOptimization.Models.FactoryProcessing;
using WorkOptimization.Models.MathematicalFunction.ObjectiveFunction;
using WorkOptimization.Models.MathematicalModel.Subjects;

namespace WorkOptimization.Models.GeneticAlgorithm
{
    public class GeneticAlgorithmController : IAlgorithm
    {
        private static readonly Random _randomNumber = new Random();
        private int _employeesNumber;
        private int _sizeOfPopulation;
        private int _numberOfIterations;
        private double _mutationRate;
        private double _percentageOfChildrenFromPreviousGeneration;
        private double _percentageOfParentsChosenToSelection;
        private FactoryController _factory;
        private List<int> _iterationResults;
        private Subjects _subjects;
        public List<Specimen> Population { get; set; }
        private List<Machines> _machineList;
        private List<Employees> _employeesList;

        public GeneticAlgorithmController(GeneticAlgorithmParameters algorithmParameteres, FactoryController factory)
        {
            _employeesNumber = algorithmParameteres.EmployeesNumber;
            _sizeOfPopulation = algorithmParameteres.SizeOfPopulation;
            _numberOfIterations = algorithmParameteres.NumberOfIterations;
            _mutationRate = algorithmParameteres.MutationRate;
            _percentageOfChildrenFromPreviousGeneration = algorithmParameteres.PercentageOfChildrenFromPreviousGeneration;
            _percentageOfParentsChosenToSelection = algorithmParameteres.PercentageOfParentsChosenToSelection;
            _factory = factory;
            _machineList = factory.MachinesList;
            _employeesList = factory.EmployeesList;
            _iterationResults = new List<int>();
            _subjects = new Subjects(factory);
            _subjects.MakeSubject();

            Population = new List<Specimen>();
            CreatePopulation(_sizeOfPopulation, _employeesNumber, _subjects);
        }
        
        private void CreatePopulation(int sizeOfPopulation, int employeesNumber, Subjects subjects)
        {
            var profitList = new List<double>();
            var sorted =  _employeesList.OrderBy(o => o.Abilities).ToList();
            for (int i = 0; i < sizeOfPopulation; i++)
            {
                Specimen specimen = new Specimen();
                for (int j =0; j < employeesNumber; j++)
                {
                    var tempList = new List<int>();
                    Employees employee = sorted[j];
                    for(int u = 0; u < employee.VectorOfAbilities.Length;u++)
                    {
                        if(employee.VectorOfAbilities[u] =='1')
                        {
                            tempList.Add(u);
                        }
                    }
                    int k = _randomNumber.Next(tempList.Count);
                    //Machines chosen = _machineList[k];
                    //while (specimen.Genome.ContainsKey(_machineList[k]))
                    while (specimen.Genome.ContainsKey(_machineList[tempList[k]]))
                    {
                        k = _randomNumber.Next(tempList.Count);
                    }
                    specimen.Genome.Add(_machineList[tempList[k]], employee);
                    profitList.Add(ObjectiveFunctionCounter.CountValueOfTheFunction(_factory,specimen));
                }
                Population.Add(specimen);
            }
        }
        
    }
}
/*
 Specimen specimen = new Specimen();
                for (int j = 0; j< employeesNumber; j++)
                {
                    List<Employees> tempList = new List<Employees>(_subjects._machinesAndItsOperators[j]);
                    int k = _randomNumber.Next(tempList.Count);
                    Employees chosen = tempList[k];
                    //while(specimen.Genome.Contains(chosen))
                    while (specimen.Genome.ContainsValue(chosen))
                    {
                        k = _randomNumber.Next(tempList.Count);
                        chosen = tempList[k];
                    }
                    specimen.Genome.Add(_machineList[j], chosen);
                }
                Population.Add(specimen);
 */
