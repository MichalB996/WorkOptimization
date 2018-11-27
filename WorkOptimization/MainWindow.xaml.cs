using System;
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
            GeneticAlgorithmParameters Parameters = GeneticAlgorithmParameters.Create(25,100,1000,0.7,0.2,2);
            GeneticAlgorithmController Controller = new GeneticAlgorithmController(Parameters,Factory);
            //int profit = ObjectiveFunctionCounter.CountValueOfTheFunction(Factory);
            //Subjects sub = new Subjects(Factory);
            //sub.MakeSubject();
            //for(int i =0; i<100;i++)
            //{

            //}
            
            Console.WriteLine("dupa");
        }
    }
}
