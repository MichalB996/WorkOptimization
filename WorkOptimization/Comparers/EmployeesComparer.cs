using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.EF;

namespace WorkOptimization.Comparers
{
    public class EmployeesComparer : IEqualityComparer<Employees>
    {
        public bool Equals(Employees employee_1, Employees employee_2)
        {
            if (employee_1.Abilities == employee_2.Abilities)
                return true;
            else return false;
        }
        public int GetHashCode(Employees employee)
        {
            return 0;
        }
    }
}
