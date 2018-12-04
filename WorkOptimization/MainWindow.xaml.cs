using System.Windows;
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
            this.DataContext = new BothAlgorithmsViewModel();
        }

    }
}
