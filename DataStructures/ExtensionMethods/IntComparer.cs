using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    class IntComparer: IComparer<int>
    {
        public int Compare(int a, int b)
        {
            if (a > b)
            {
                return 1;
            }
            else if (a < b)
            {
                return -1;
            }
            return 0;
        }


        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}
