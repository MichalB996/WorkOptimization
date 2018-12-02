using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WorkOptimization.Models.Plotter
{
    public class Plotter
    {
        public static Collection<CollectionDataValue> Plot(List<double> toPlotData)
        {
            var plotData = new Collection<CollectionDataValue>();

            for (int i = 0; i < toPlotData.Count; i++)
            {
                plotData.Add(new CollectionDataValue
                {
                    XData = i + 1,
                    YData = toPlotData[i]
                });
            }

            return plotData;
        }
    }
}
