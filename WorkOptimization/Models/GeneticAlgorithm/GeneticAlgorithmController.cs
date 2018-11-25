using System;
using System.Collections.Generic;
using System.Linq;
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
        private Subjects _subjects;
        public List<Specimen> Population { get; set; }

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
                }
                specimen.Profit = ObjectiveFunctionCounter.CountValueOfTheFunction(_factory, specimen);                
                Population.Add(specimen);              
            }
            Population = Population.OrderBy(o => o.Profit).Reverse().ToList();
            UpdatePopulation(Population,_numberOfIterations);
        }

        public void UpdatePopulation(List<Specimen> population, int numberOfIterations)
        {
            var tempPopulation = new List<Specimen>(population);
            var nextPopulation = new List<Specimen>();
            for (int i = 0; i < tempPopulation.Count; i++)
            {
                var spec = CrossoverTwoSpecimens(tempPopulation);
                nextPopulation.Add(spec);
            }

            Mutate(Population, _mutationRate);
            for (int i = 0; i < Population.Count; i++)
            {
                CrossoverTwoSpecimens(Population);
            }
        }

        public Specimen CrossoverTwoSpecimens(List<Specimen> Population)
        {
            int specimensFromEarlierPopulation = (int)(_percentageOfChildrenFromPreviousGeneration * Population.Count);
            List<Specimen> newPopulation = new List<Specimen>(Population.GetRange(0, specimensFromEarlierPopulation));
            Specimen specimen_1 = Population[_randomNumber.Next(Population.Count)];
            Specimen specimen_2 = Population[_randomNumber.Next(Population.Count)];
            Specimen result_specimen = Crossover(specimen_1, specimen_2);
            result_specimen.Profit = ObjectiveFunctionCounter.CountValueOfTheFunction(_factory, result_specimen);
            return result_specimen;
        }

        public Specimen Crossover(Specimen specimen_1, Specimen specimen_2)
        {
            var specimen_1_genome_copy = new Dictionary<Machines, Employees>(specimen_1.Genome);
            var specimen_2_genome_copy = new Dictionary<Machines, Employees>(specimen_2.Genome);
            Specimen result = new Specimen();
            int k = _randomNumber.Next(specimen_1.Genome.Count);
            var pair_1_gen_1 = specimen_1_genome_copy.ToList()[k];
            var pair_1_gen_2 = specimen_2_genome_copy.ToList().Find(o => o.Key == pair_1_gen_1.Key);
            var pair_2_gen_2 = specimen_2_genome_copy.ToList().Find(o => o.Value == pair_1_gen_1.Value);
            var pair_2_gen_1 = specimen_1_genome_copy.ToList().Find(o => o.Value == pair_1_gen_2.Value);
            if (pair_1_gen_1.Key == pair_2_gen_1.Key)
            {
                return specimen_1;

            }
            if (pair_1_gen_1.Key == pair_1_gen_2.Key && pair_2_gen_1.Key == pair_2_gen_2.Key)
            {
                result.Genome.Add(pair_1_gen_1.Key, pair_1_gen_1.Value);
                result.Genome.Add(pair_2_gen_1.Key, pair_1_gen_2.Value);
                specimen_2_genome_copy.Remove(pair_1_gen_1.Key);
                specimen_2_genome_copy.Remove(pair_2_gen_1.Key);
                foreach (KeyValuePair<Machines, Employees> kvp in specimen_2_genome_copy)
                {
                    result.Genome.Add(kvp.Key, kvp.Value);
                }
                var gen = result.Genome.ToList().OrderBy(o => o.Value.Abilities);
                var genome = gen.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
                result.Genome = genome;
                return result;
            }
            var free_machine_from_pair_2_gen_2 = pair_2_gen_2.Key;
            var free_employee_from_gen_2 = specimen_2.Genome[pair_2_gen_1.Key];
            var free_machine_number = _factory.MachinesList.IndexOf(free_machine_from_pair_2_gen_2);
            if (free_employee_from_gen_2.VectorOfAbilities[free_machine_number] == '1')
            {
                result.Genome.Add(pair_1_gen_1.Key, pair_1_gen_1.Value);
                result.Genome.Add(pair_2_gen_1.Key, pair_2_gen_1.Value);
                result.Genome.Add(free_machine_from_pair_2_gen_2, free_employee_from_gen_2);
                specimen_2_genome_copy.Remove(pair_1_gen_1.Key);
                specimen_2_genome_copy.Remove(pair_2_gen_1.Key);
                specimen_2_genome_copy.Remove(free_machine_from_pair_2_gen_2);
                foreach (KeyValuePair<Machines, Employees> kvp in specimen_2_genome_copy)
                {
                    result.Genome.Add(kvp.Key, kvp.Value);
                }
                var gen = result.Genome.ToList().OrderBy(o => o.Value.Abilities);
                var genome = gen.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
                result.Genome = genome;
                return result;
            }
            else
            {
                var employeesList = _factory.EmployeesList.FindAll(
                    s => s.VectorOfAbilities[free_machine_number] == '1' && s.EmployeeID != pair_1_gen_1.Value.EmployeeID
                    && s.EmployeeID != pair_2_gen_1.Value.EmployeeID);

                int k2 = _randomNumber.Next(employeesList.Count);
                var drewn_employee = employeesList[k2];
                var drewn_employeee_and_its_machine = specimen_2.Genome.ToList().Find(o => o.Value == drewn_employee);
                var drewn_employee_machine_number = _factory.MachinesList.IndexOf(drewn_employeee_and_its_machine.Key);
                int counter = 0;
                while (free_employee_from_gen_2.VectorOfAbilities[drewn_employee_machine_number] != '1' && counter < 10)
                {
                    counter++;
                    employeesList = _factory.EmployeesList.FindAll(
                                    s => s.VectorOfAbilities[free_machine_number] == '1' && s.EmployeeID != pair_1_gen_1.Value.FactoryID
                                    && s.EmployeeID != pair_2_gen_1.Value.FactoryID);

                    employeesList.Remove(pair_1_gen_1.Value);
                    employeesList.Remove(pair_2_gen_1.Value);


                    k2 = _randomNumber.Next(employeesList.Count);
                    drewn_employee = employeesList[k2];
                    drewn_employeee_and_its_machine = specimen_2.Genome.ToList().Find(o => o.Value == drewn_employee);
                    drewn_employee_machine_number = _factory.MachinesList.IndexOf(drewn_employeee_and_its_machine.Key);
                }
                if (counter == 10)
                {
                    return specimen_1;
                }
                result.Genome.Add(pair_1_gen_1.Key, pair_1_gen_1.Value);
                result.Genome.Add(pair_2_gen_1.Key, pair_2_gen_1.Value);
                result.Genome.Add(_factory.MachinesList[drewn_employee_machine_number], free_employee_from_gen_2);
                result.Genome.Add(_factory.MachinesList[free_machine_number], drewn_employee);
                specimen_2_genome_copy.Remove(pair_1_gen_1.Key);
                specimen_2_genome_copy.Remove(pair_2_gen_1.Key);
                specimen_2_genome_copy.Remove(_factory.MachinesList[drewn_employee_machine_number]);
                specimen_2_genome_copy.Remove(_factory.MachinesList[free_machine_number]);


                foreach (KeyValuePair<Machines, Employees> kvp in specimen_2_genome_copy)
                {
                    result.Genome.Add(kvp.Key, kvp.Value);
                }
                //return result;
                var gen = result.Genome.ToList().OrderBy(o => o.Value.Abilities);
                var genome = gen.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
                result.Genome = genome;
                return result;
            }
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

