using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOptimization.CreateResultFile
{
    public class CreateFile
    {
        public static void CreateResultFile(List<double> results)
        {
            results.Sort();
            using (TextWriter tw = new StreamWriter("C:\\Users\\Michał\\Desktop\\ResultFile.txt"))
            {
                foreach (int i in results)
                    tw.WriteLine(i);
            }
        }
    }
}
