using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.EF;
using WorkOptimization.Models.FactoryProcessing;

namespace WorkOptimization.Models.EmployeeProcessing
{
    public class FactoryProcessing : IFactory
    {
        private List<Employees> EmployeesList { get; set; }
        private List<Machines> MachinesList { get; set; }
        private List<Factories> FactoriesList { get; set; }

        private FactoryProcessing()
        {
            EmployeesList = new List<Employees>();
            MachinesList = new List<Machines>();
            FactoriesList = new List<Factories>();
            GetDataFromDatabase();
        }

        private void GetDataFromDatabase()
        {
            using (var context = new FactoryEntities())
            {
                foreach (Employees e in context.Employees)
                {
                    HexProcessing(e, 6);
                }
                foreach(Factories f in context.Factories)
                {
                    FactoriesList.Add(f);
                }
                foreach(Machines m in context.Machines)
                {
                    MachinesList.Add(m);
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
            }
            if (binaryString.Length > numberOfWorkers)
            {
                var a = binaryString.Length - numberOfWorkers;
                var b = binaryString.Length - 2;
                binaryString = binaryString.Substring(a, b);
            }
            if (binaryString.Length != numberOfWorkers)
                throw new Exception("Number of Abilities is not equal to number of machines!");
            employee.VectorOfAbilities = binaryString;
            EmployeesList.Add(employee);
        }

        public static FactoryProcessing Create()
            => new FactoryProcessing();
    }
}
