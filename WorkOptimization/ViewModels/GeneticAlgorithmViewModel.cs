using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOptimization.Models.GeneticAlgorithm;

namespace WorkOptimization.ViewModels
{
    public class GeneticAlgorithmViewModel
    {
        private GeneticAlgorithmParameters _GeneticAlgorithm;
        public GeneticAlgorithmParameters GeneticAlgorithm
        {
            get
            {
                return _GeneticAlgorithm;
            }

        }
        public GeneticAlgorithmViewModel()
        {
           // _GeneticAlgorithm = new GeneticAlgorithmParameters();
        }
    }
}
