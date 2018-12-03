﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WorkOptimization.ViewModels.Commands
{
    public class CreateCommand : ICommand
    {
        public GeneticAlgorithmViewModel GeneticAlgorithm {get; set;}
        public event EventHandler CanExecuteChanged;
        public CreateCommand(GeneticAlgorithmViewModel x)
        {
            this.GeneticAlgorithm = x;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.GeneticAlgorithm.CreateMethod();
        }
    }
}
