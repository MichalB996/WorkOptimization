﻿using System;
using System.Collections.Generic;
using System.Linq;
using WorkOptimization.EF;
using WorkOptimization.Models.BessAlgorithm;
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
                int DailyHours = 8;
                for (int i = 0; i < DailyHours; i++)
                {
                    if(abilities < specializedLimit)
                    {
                        double percentage = _randomNumber.Next(normalWorkerBonus)/100;
                        if (kvp.Key.Special == 0)
                        {
                            machineProfit += (kvp.Key.Profit_1 * kvp.Key.Efficiency_1);
                            payout += 40 * abilities;
                        }
                        if (kvp.Key.Special == 1 && kvp.Key.Profit_2 != null)
                        {
                            machineProfit += (kvp.Key.Profit_1 * kvp.Key.Efficiency_1 + kvp.Key.Profit_2.Value * kvp.Key.Efficiency_2.Value) * 1;
                            payout += 40 * abilities;
                        }
                    }
                    else
                    {
                        double percentage = expiriencedWorker/100;
                        if (kvp.Key.Special == 0)
                        {
                            machineProfit += (kvp.Key.Profit_1 * kvp.Key.Efficiency_1) * 1;
                            payout += 50 * abilities * 1;
                        }
                        if (kvp.Key.Special == 1 && kvp.Key.Profit_2 != null)
                        {
                            machineProfit += (kvp.Key.Profit_1 * kvp.Key.Efficiency_1 + kvp.Key.Profit_2.Value * kvp.Key.Efficiency_2.Value) * 1;
                            payout += 50 * abilities * 1.5;
                        }
                        
                    }
                }
            }
            return machineProfit - payout;
        }

        public static double CountValueOfTheFunction(Bee bee, int specializedLimit, int extraHours)
        {
            int normalWorkerBonus = 5;
            double expiriencedWorker = 3;
            Random _randomNumber = GeneticAlgorithmController._randomNumber;
            double payout = 0;
            double machineProfit = 0;

            foreach (KeyValuePair<Machines, Employees> kvp in bee.Trail)
            {
                int abilities = kvp.Value.VectorOfAbilities.Count(s => s.Equals('1'));
                int DailyHours = 8;
                for (int i = 0; i < DailyHours; i++)
                {
                    if (abilities < specializedLimit)
                    {
                        double percentage = _randomNumber.Next(normalWorkerBonus) / 100;
                        if (kvp.Key.Special == 0)
                        {
                            machineProfit += (kvp.Key.Profit_1 * kvp.Key.Efficiency_1);
                            payout += 40 * abilities;
                        }
                        if (kvp.Key.Special == 1 && kvp.Key.Profit_2 != null)
                        {
                            machineProfit += (kvp.Key.Profit_1 * kvp.Key.Efficiency_1 + kvp.Key.Profit_2.Value * kvp.Key.Efficiency_2.Value) * 1;
                            payout += 40 * abilities;
                        }
                    }
                    else
                    {
                        double percentage = expiriencedWorker / 100;
                        if (kvp.Key.Special == 0)
                        {
                            machineProfit += (kvp.Key.Profit_1 * kvp.Key.Efficiency_1) * 1;
                            payout += 50 * abilities * 1;
                        }
                        if (kvp.Key.Special == 1 && kvp.Key.Profit_2 != null)
                        {
                            machineProfit += (kvp.Key.Profit_1 * kvp.Key.Efficiency_1 + kvp.Key.Profit_2.Value * kvp.Key.Efficiency_2.Value) * 1;
                            payout += 50 * abilities * 1.5;
                        }
                    }
                }
            }
            return machineProfit - payout;
        }

    }
}