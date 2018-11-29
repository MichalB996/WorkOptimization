using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.EF;
using WorkOptimization.Models.FactoryProcessing;
using WorkOptimization.Models.GeneticAlgorithm;

namespace WorkOptimization.Models.MathematicalModel.ObjectiveFunction
{
    public class ObjectiveFunctionCounter_1
    {
        public static int DailyMinimumHours = 8;

        public static double CountValueOfTheFunction(Specimen specimen, int specializedLimit, int extraHours)
        {
            int normalWorkerBonus = 5;
            double expiriencedWorker = 3;
            Random _randomNumber = GeneticAlgorithmController._randomNumber;
            double payout = 0;
            double machineProfit = 0;

            foreach (KeyValuePair<Machines, Employees> kvp in specimen.Genome)
            {
                int abilities = kvp.Value.VectorOfAbilities.Count(s => s.Equals('1'));
                //int DailyHours = DailyMinimumHours + _randomNumber.Next(extraHours);
                int DailyHours = 8;
                for (int i = 0; i < DailyHours; i++)
                {
                    if(abilities < specializedLimit)
                    {
                        double percentage = _randomNumber.Next(normalWorkerBonus)/100;
                        if (kvp.Key.Special == 0)
                        {
                            machineProfit += (kvp.Key.Profit_1 * kvp.Key.Efficiency_1);//*(1+percentage);
                            payout += 40 * abilities;// * 1.5; //* (1 + percentage);
                        }
                        if (kvp.Key.Special == 1 && kvp.Key.Profit_2 != null)
                        {
                            machineProfit += (kvp.Key.Profit_1 * kvp.Key.Efficiency_1 + kvp.Key.Profit_2.Value * kvp.Key.Efficiency_2.Value) * 1;// (1+percentage);
                            payout += 40 * abilities;
                        }
                        //payout += 20 * abilities*(1+percentage)*1.5;
                        //payout += 40 * abilities;// * 1.5; //* (1 + percentage);
                    }
                    else
                    {
                        double percentage = expiriencedWorker/100;
                        if (kvp.Key.Special == 0)
                        {
                            machineProfit += (kvp.Key.Profit_1 * kvp.Key.Efficiency_1) * 1;//(1 + percentage);
                            payout += 50 * abilities * 1;//(1 + percentage);
                        }
                        if (kvp.Key.Special == 1 && kvp.Key.Profit_2 != null)
                        {
                            machineProfit += (kvp.Key.Profit_1 * kvp.Key.Efficiency_1 + kvp.Key.Profit_2.Value * kvp.Key.Efficiency_2.Value) * 1;//(1 + percentage);
                            //payout += 30 * abilities * (1 + percentage)*1.5;
                            payout += 50 * abilities * 1.5;//* (1 + percentage) ;
                        }
                        
                    }
                }
            }
            return machineProfit - payout;
        }

    }
}