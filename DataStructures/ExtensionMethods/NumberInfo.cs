using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    class NumberInfo
    {
        public double Key;
        public IEnumerable<double> Values;

        public NumberInfo(double key, IEnumerable<double> values)
        {
            this.Key = key;
            this.Values = values;
        }
    }
}
