using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.EF;
using WorkOptimization.Models.FactoryProcessing;

namespace WorkOptimization.Models.MathematicalModel.Subjects
{
    public class Subjects
    {
        private List<Employees> _employeesList;
        //private Dictionary<int,> _employessMachines;
        public Dictionary<int, List<Employees>> _machinesAndItsOperators;

        public Subjects(FactoryController factory)
        {
            _employeesList = new List<Employees>(factory.EmployeesList);
            _machinesAndItsOperators = new Dictionary<int, List<Employees>>();
        }

        public void MakeSubject()
        {
            for (int i = 0; i < _employeesList.Count; i++)
            {
                List<Employees> tempList = new List<Employees>();
                foreach (Employees e in _employeesList)
                {
                    if (e.VectorOfAbilities[i] == '1')
                    {
                        tempList.Add(e);
                    }
                }
                _machinesAndItsOperators.Add(i, tempList);
            }
        }
    }
}
