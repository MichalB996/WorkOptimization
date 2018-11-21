using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.EF;

namespace WorkOptimization.Comparers
{
    class MachinesComparer : IEqualityComparer<Machines>
    {
        public bool Equals(Machines machine_1, Machines machine_2)
        {
            if (machine_1.MachineID == machine_2.MachineID)
                return true;
            else return false;
        }

        public int GetHashCode(Machines machine)
        {
            return 0;
        }
    }
}
