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
            _subjects = new Subjects(factory);
            _subjects.MakeSubject();

            Population = new List<Specimen>();
            CreatePopulation(_sizeOfPopulation, _employeesNumber, _subjects);
        }
        
        private void CreatePopulation(int sizeOfPopulation, int employeesNumber, Subjects subjects)
        {
            var profitList = new List<double>();
            var sorted =  _factory.EmployeesList.OrderBy(o => o.Abilities).ToList();
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
                    while (specimen.Genome.ContainsKey(_factory.MachinesList[tempList[k]]))
                    {
                        k = _randomNumber.Next(tempList.Count);
                    }
                    specimen.Genome.Add(_factory.MachinesList[tempList[k]], employee);
                    profitList.Add(ObjectiveFunctionCounter.CountValueOfTheFunction(_factory,specimen));
                }
                Population.Add(specimen);              
            }
            Mutate(Population, _mutationRate);
        }
        
        public void Crossover()
        {

        }

        public void Mutate(List<Specimen> population, double mutationRate)
        {
            for(int i =0; i < population.Count; i++)
            {
                double k = _randomNumber.NextDouble();
                if ( k  < _mutationRate)
                {
                    population[i].Genome = MutateSpecimen(population[i].Genome);
                }
            }
        }

        public Dictionary<Machines, Employees> MutateSpecimen(Dictionary<Machines, Employees> genome)
        {
            int counter = 0;
            var genomeList = genome.ToList();
            int k1 = _randomNumber.Next(genome.Count);
            var machineNumber = _factory.MachinesList.IndexOf(genomeList[k1].Key);
            var employeesList = _factory.EmployeesList.FindAll(
                                s => s.VectorOfAbilities[machineNumber] == '1' && s.EmployeeID != genomeList[k1].Value.EmployeeID);
            int k2 = _randomNumber.Next(employeesList.Count);
            var machine_1 = genomeList.Find(s => s.Value.EmployeeID == employeesList[k2].EmployeeID);
            int machine_2_Number = _factory.MachinesList.IndexOf(machine_1.Key);
            while(genomeList[k1].Value.VectorOfAbilities[machine_2_Number] != '1' && counter < employeesList.Count)
            {
                k2 = _randomNumber.Next(employeesList.Count);
                while (k1 == k2)
                {
                    k2 = _randomNumber.Next(employeesList.Count);
                }
                machine_1 = genomeList.Find(s => s.Value.EmployeeID == employeesList[k2].EmployeeID);
                machine_2_Number = _factory.MachinesList.IndexOf(machine_1.Key);
                counter++;
            }
            if(counter != employeesList.Count)
            {
                genome.Remove(genomeList[k1].Key);
                genome.Remove(machine_1.Key);
                genome.Add(genomeList[k1].Key, employeesList[k2]);
                genome.Add(machine_1.Key, genomeList[k1].Value);
                var genome_1 = genome.ToList();
                genome_1.OrderBy(o => o.Value.Abilities);
                var c = genome.OrderBy(o => o.Value.Abilities);
                genome = c.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
            }

            return genome;
        }
    }
}

