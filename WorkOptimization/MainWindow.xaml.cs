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
using WorkOptimization.Models.ObjectiveFunction;
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
            GeneticAlgorithmParameters Parameters = GeneticAlgorithmParameters.Create(6,100,100,1,2,2);
            FactoryController Factory = FactoryController.Create();
            int profit = ObjectiveFunctionCounter.CountValueOfTheFunction(Factory);
        }
    }
}
