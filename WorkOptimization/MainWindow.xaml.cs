using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkOptimization.EF;
using WorkOptimization.Models.FactoryProcessing;
using WorkOptimization.Models.GeneticAlgorithm;
using WorkOptimization.Models.MathematicalFunction.ObjectiveFunction;
using WorkOptimization.Models.MathematicalModel.Subjects;

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
            GeneticAlgorithmParameters Parameters = GeneticAlgorithmParameters.Create(6,50,100,0.2,0.1,2);

            //int profit = ObjectiveFunctionCounter.CountValueOfTheFunction(Factory);
            Subjects sub = new Subjects(Factory);
            //sub.MakeSubject();
            GeneticAlgorithmController Controller = new GeneticAlgorithmController(Parameters,Factory);
            Console.WriteLine("dupa");
        }
    }
}
