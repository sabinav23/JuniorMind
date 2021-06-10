using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ExtensionMethods
{
    class MultipleComparer<T> : IComparer<T>
    {

        private IComparer<T> first;
        private IComparer<T> second;

        public MultipleComparer(IComparer<T> first, IComparer<T> second)
        {
            this.first = first;
            this.second = second;
        }
        public int Compare([AllowNull] T x, [AllowNull] T y)
        {
            int firstComparison = first.Compare(x, y);
            if (firstComparison != 0)
            {
                return firstComparison;
            }
            return second.Compare(x, y);
        }
    }
}
