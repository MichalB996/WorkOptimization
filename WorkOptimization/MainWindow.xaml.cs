﻿using System;
using System.Windows;
using WorkOptimization.Models.FactoryProcessing;
using WorkOptimization.Models.GeneticAlgorithm;

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
            FactoryController Factory = FactoryController.Create();
            GeneticAlgorithmParameters Parameters = GeneticAlgorithmParameters.Create(25,20,100,1,0.2,2);
            GeneticAlgorithmController Controller = new GeneticAlgorithmController(Parameters,Factory);

        }
    }
}
