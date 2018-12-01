using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.CreateResultFile;
using WorkOptimization.EF;
using WorkOptimization.Models.FactoryProcessing;
using WorkOptimization.Models.MathematicalModel.ObjectiveFunction;
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
            CreateFirstPopulation(_sizeOfPopulation, _employeesNumber, _subjects);
        }

        private void CreateFirstPopulation(int sizeOfPopulation, int employeesNumber, Subjects subjects)
        {
            var profitList = new List<double>();
            var sorted = _factory.EmployeesList.OrderBy(o => o.Abilities).ToList();
            for (int i = 0; i < sizeOfPopulation; i++)
            {
                Population.Add(CreateBee(employeesNumber));
            }
            Population = Population.OrderBy(o => o.Profit).ToList();
            _iterationResults.Add(Population[Population.Count-1].Profit);
            for(int i =0; i< _numberOfIterations; i++)
            {
                NeigbourhoodSearch(Population);
            }
            CreateFile.CreateResultFile(_iterationResults);
        }
    
        public Bee CreateBee(int employeesNumber)
        {
            var sorted = _factory.EmployeesList.OrderBy(o => o.Abilities).ToList();
            Bee bee = new Bee();
            for (int i = 0; i < employeesNumber; i++)
            {
                var tempList = new List<int>();
                var tempMachinesList = new List<Machines>();
                Employees employee = sorted[i];
                for (int u = 0; u < employee.VectorOfAbilities.Length; u++)
                {
                    if (employee.VectorOfAbilities[u] == '1')
                    {
                        tempList.Add(u);
                        tempMachinesList.Add(_factory.MachinesList[u]);
                    }
                }
                tempMachinesList.RemoveAll(item => bee.Trail.Keys.ToList().Contains(item));
                if (tempMachinesList.Count != 0)
                {
                    bee.Trail.Add(tempMachinesList[_randomNumber.Next(tempMachinesList.Count)], employee);
                }
                else
                {
                    bee = CreateBee(employeesNumber);
                }
            }
            bee.Profit = bee.Profit = ObjectiveFunctionCounter_1.CountValueOfTheFunction(bee, 11, 2);

            return bee;
        }

        public void NeigbourhoodSearch(List<Bee> Population)
        {
            var newPopulation = new List<Bee>();
            Population.Reverse();
            int numberOfEliteBees = (int)(_numberOfEliteBees * Population.Count);
            int numberOfAcceptableBees = (int)(_numberOfAcceptableBees * Population.Count);
            List<Bee> EliteBees = new List<Bee>(Population.GetRange(0, numberOfEliteBees));
            List<Bee> AcceptableBees = new List<Bee>(Population.GetRange(numberOfEliteBees, numberOfAcceptableBees));
            for(int i = 0; i < Population.Count - numberOfEliteBees - numberOfAcceptableBees; i++)
            {
                newPopulation.Add(CreateBee(_employeesNumber));
            }
            foreach(Bee bee in EliteBees)
            {
                var newBee = SearchBetterTrail(bee);
                newPopulation.Add(SearchBetterTrail(newBee));
            }
            foreach(Bee bee in AcceptableBees)
            {
                var newBee = SearchBetterTrail(bee);
                newBee = SearchBetterTrail(newBee);
                newBee = SearchBetterTrail(newBee);
                newPopulation.Add(SearchBetterTrail(newBee));
            }
            newPopulation = newPopulation.OrderBy(o => o.Profit).ToList();
            _iterationResults.Add(newPopulation[newPopulation.Count-1].Profit);
        }

        public Bee SearchBetterTrail(Bee bee)
        {
            Bee newBee = new Bee(bee.Trail);
            int counter = 0;
            var trailList = bee.Trail.ToList();
            int k1 = _randomNumber.Next(trailList.Count);
            var machine_1_Number = _factory.MachinesList.IndexOf(trailList[k1].Key);
            var employeesListAbleToWorkOnMachine_1 = _factory.EmployeesList.FindAll(
                                s => s.VectorOfAbilities[machine_1_Number] == '1' && s.EmployeeID != trailList[k1].Value.EmployeeID);
            int k2 = _randomNumber.Next(employeesListAbleToWorkOnMachine_1.Count);
            var machine_2 = trailList.Find(s => s.Value.EmployeeID == employeesListAbleToWorkOnMachine_1[k2].EmployeeID).Key;
            int machine_2_Number = _factory.MachinesList.IndexOf(machine_2);
            while (trailList[k1].Value.VectorOfAbilities[machine_2_Number] != '1' && counter < employeesListAbleToWorkOnMachine_1.Count)
            {
                k2 = _randomNumber.Next(employeesListAbleToWorkOnMachine_1.Count);
                while (k1 == k2)
                {
                    k2 = _randomNumber.Next(employeesListAbleToWorkOnMachine_1.Count);
                }
                machine_2 = trailList.Find(s => s.Value.EmployeeID == employeesListAbleToWorkOnMachine_1[k2].EmployeeID).Key;
                machine_2_Number = _factory.MachinesList.IndexOf(machine_2);
                counter++;
            }
            if (counter != employeesListAbleToWorkOnMachine_1.Count)
            {
                newBee.Trail.Remove(trailList[k1].Key);
                newBee.Trail.Remove(machine_2);
                newBee.Trail.Add(trailList[k1].Key, employeesListAbleToWorkOnMachine_1[k2]);
                newBee.Trail.Add(machine_2, trailList[k1].Value);
                var Trail_1 = newBee.Trail.ToList();
                Trail_1.OrderBy(o => o.Value.Abilities);
                var c = newBee.Trail.OrderBy(o => o.Value.Abilities);
                newBee.Trail = c.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
                newBee.Profit = ObjectiveFunctionCounter_1.CountValueOfTheFunction(newBee,11,3);
            }

            return newBee.Profit > bee.Profit ? newBee : bee;
        }

    }
    
}
