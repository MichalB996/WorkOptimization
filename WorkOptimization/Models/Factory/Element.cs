using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOptimization.Models.Factory
{
    class Element
    {
        private int _uniqueID;
        private int _profit;

        public int UniqueID
        {
            get
            {
                return _uniqueID;
            }

            set
            {
                if (_uniqueID == value)
                {
                    return;
                }

                _uniqueID = value;
            }
        }

        public int Profit
        {
            get
            {
                return _profit;
            }

            set
            {
                if (_profit == value)
                {
                    return;
                }

                _profit = value;
            }
        }
    }
}
