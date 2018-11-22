using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.Comparers;
using WorkOptimization.EF;

namespace WorkOptimization.Models.GeneticAlgorithm
{
    public class Specimen 
    {
        public Dictionary<Machines, Employees> Genome { get; set; }
        public double Profit { get; set; }

        public Specimen()
        {
            Genome = new Dictionary<Machines, Employees>(new MachinesComparer());
        }
    }
}
