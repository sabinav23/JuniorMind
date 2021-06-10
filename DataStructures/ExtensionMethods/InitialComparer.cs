using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    class InitialComparer : IComparer<string>
    {
        public int Compare(string a, string b)
        {
            return a.CompareTo(b);
        }


        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}
