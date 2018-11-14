using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOptimization.Models.Factory
{
    class Employee
    {
        private int _uniqueID;
        private int _abilities;
        private int _hourlyRate;
        private List<int> _vectorOfAbilities;

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

        public int Abilities
        {
            get
            {
                return _abilities;
            }

            set
            {
                if (_abilities == value)
                {
                    return;
                }

                _abilities = value;
            }
        }

        public int HourlyRate
        {
            get
            {
                return _hourlyRate;
            }

            set
            {
                if (_hourlyRate == value)
                {
                    return;
                }

                _hourlyRate = value;
            }
        }

        public List<int> VectorOfAbilities
        {
            get
            {
                return _vectorOfAbilities;
            }

            set
            {
                if (_vectorOfAbilities == value)
                {
                    return;
                }

                _vectorOfAbilities = value;
            }
        }
    }
}
