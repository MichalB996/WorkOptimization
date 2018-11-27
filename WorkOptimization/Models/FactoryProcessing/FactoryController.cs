using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.EF;
using WorkOptimization.Models.FactoryProcessing;

namespace WorkOptimization.Models.FactoryProcessing
{
    public class FactoryController : IFactory
    {
        private List<Employees> _employeesList { get; set; }
        private List<Machines> _machinesList { get; set; }
        private List<Factories> _factoriesList { get; set; }

        public List<Employees> EmployeesList
        {
            get
            {
                return _employeesList;
            }

            set
            {
                if (_employeesList == value)
                {
                    return;
                }

                _employeesList = value;
            }
        }

        public List<Machines> MachinesList
        {
            get
            {
                return _machinesList;
            }

            set
            {
                if (_machinesList == value)
                {
                    return;
                }

                _machinesList = value;
            }
        }

        public List<Factories> FactoriesList
        {
            get
            {
                return _factoriesList;
            }

            set
            {
                if (_factoriesList == value)
                {
                    return;
                }

                _factoriesList = value;
            }
        }
        private FactoryController()
        {
            _employeesList = new List<Employees>();
            _machinesList = new List<Machines>();
            _factoriesList = new List<Factories>();
            GetDataFromDatabase();
        }

        private void GetDataFromDatabase()
        {
            using (var context = new FactoryEntities())
            {
                foreach (Employees e in context.Employees)
                {
                    HexProcessing(e, 25);
                }
                foreach(Factories f in context.Factories)
                {
                    _factoriesList.Add(f);
                }
                foreach(Machines m in context.Machines)
                {
                    _machinesList.Add(m);
                }
            }
        }

        public void HexProcessing(Employees employee, int numberOfWorkers)
        {
            // Convert integer as a hex in a string variable
            string hexValue = employee.Abilities.ToString("X");
            // Creates string binary array
            string binaryString = String.Join(
                                  String.Empty, hexValue.Select(
                                  c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            if (binaryString.Length < numberOfWorkers)
            {
                string s = "";
                int val = numberOfWorkers - binaryString.Length;
                for (int i = 0; i < val; i++)
                {
                    s = s + "0";
                }
                binaryString = s + binaryString;
            }/*
            if (binaryString.Length > numberOfWorkers)
            {
                var a = binaryString.Length - numberOfWorkers;
                var b = binaryString.Length - 2;
                binaryString = binaryString.Substring(a, b);
            }*/
            if (binaryString.Length > numberOfWorkers && numberOfWorkers >= 25)
            {
                var a = binaryString.Length - numberOfWorkers;
                //var b = binaryString.Length - 2;
                binaryString = binaryString.Substring(a, binaryString.Length - 3);
            }
            else if (binaryString.Length > numberOfWorkers)
            {
                var a = binaryString.Length - numberOfWorkers;
                var b = binaryString.Length - 2;
                binaryString = binaryString.Substring(a, b);
            }
            if (binaryString.Length != numberOfWorkers)
                throw new Exception("Number of Abilities is not equal to number of machines!");
            employee.VectorOfAbilities = binaryString;
            _employeesList.Add(employee);
        }

        public static FactoryController Create()
            => new FactoryController();
    }
}
