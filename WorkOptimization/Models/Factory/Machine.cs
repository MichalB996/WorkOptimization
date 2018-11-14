using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOptimization.Models.Factory
{
    class Machine
    {
        private int _uniqueID;
        private Element _element;
        private int _productivity;

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

        public Element Element
        {
            get
            {
                return _element;
            }

            set
            {
                if (_element == value)
                {
                    return;
                }

                _element = value;
            }
        }

        public int Productivity
        {
            get
            {
                return _productivity;
            }

            set
            {
                if (_productivity == value)
                {
                    return;
                }

                _productivity = value;
            }
        }
    }
}
