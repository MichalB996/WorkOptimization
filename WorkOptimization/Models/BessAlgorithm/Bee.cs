using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.Comparers;
using WorkOptimization.EF;

namespace WorkOptimization.Models.BessAlgorithm
{
    public class Bee
    {
        public Dictionary<Machines, Employees> Trail { get; set; }
        public double Profit { get; set; }

        public Bee()
        {
            Trail = new Dictionary<Machines, Employees>(new MachinesComparer());
        }
        public Bee(Dictionary<Machines, Employees> dict)
        {
            Trail = new Dictionary<Machines, Employees>(dict,new MachinesComparer());
        }
    }
}
