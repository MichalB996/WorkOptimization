using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.EF;
using WorkOptimization.Models.Factory;
using WorkOptimization.Models.FactoryProcessing;
using WorkOptimization.Models.GeneticAlgorithm;

namespace WorkOptimization.Models.MathematicalFunction.ObjectiveFunction
{
    public static class ObjectiveFunctionCounter
    {
        public static int DailyHours = 8;

        public static double CountValueOfTheFunction(FactoryController factory, Specimen specimen)
        {
            double Payouts = 0;
            double FactoryProfit = FactoryProfitCounter(factory);
            foreach(KeyValuePair<Machines,Employees> e in specimen.Genome)
            {
                double val = 0;
                for (int i =0; i < e.Value.VectorOfAbilities.Length; i++)
                {
                    if(e.Value.VectorOfAbilities[i] == '1')
                    {
                        val++;
                    }
                }
                if(e.Key.Special == 1)
                {
                    Payouts += (val * 5) * 1.5;
                }
                else
                {
                    Payouts += (val * 5);
                }
                
            }

            return FactoryProfit - Payouts;

        }
        private static int FactoryProfitCounter(FactoryController factory)
        {
            int profit = 0;
            foreach(Machines m in factory.MachinesList)
            {

                if (m.Special == 0)
                {
                    profit += m.Profit_1 * m.Efficiency_1;
                }
                if (m.Special == 1 && m.Profit_2 != null)
                {
                    profit += (m.Profit_1 * m.Efficiency_1 + m.Profit_2.Value * m.Efficiency_2.Value);
                }
            }
            return profit;

        }
    }
}
