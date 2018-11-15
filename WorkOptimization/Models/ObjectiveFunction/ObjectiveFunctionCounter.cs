﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.EF;
using WorkOptimization.Models.Factory;
using WorkOptimization.Models.FactoryProcessing;

namespace WorkOptimization.Models.ObjectiveFunction
{
    public static class ObjectiveFunctionCounter
    {
        public static int DailyHours = 8;

        public static int CountValueOfTheFunction(FactoryController factory)
        {

            int FactoryProfit = FactoryProfitCounter(factory);


            return 0;

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
