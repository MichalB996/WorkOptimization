﻿using System;
using System.Windows;
using WorkOptimization.Models.BessAlgorithm;
using WorkOptimization.Models.FactoryProcessing;
using WorkOptimization.Models.GeneticAlgorithm;
using WorkOptimization.ViewModels;

namespace WorkOptimization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new GeneticAlgorithmViewModel();
            this.DataContext = new BeeAlgorithmViewModel();
            //FactoryController Factory = FactoryController.Create();
            //GeneticAlgorithmParameters Parameters = GeneticAlgorithmParameters.Create(25,20,100,1,0.2,2);
            //GeneticAlgorithmController Controller = new GeneticAlgorithmController(Parameters,Factory);
            //BeesAlgorithmParameters BeesParameters = BeesAlgorithmParameters.Create(25, 50, 500,0.001,0.001);
            //BeesAlgorithmController BeeController = new BeesAlgorithmController(BeesParameters,Factory);
        }

    }
}
