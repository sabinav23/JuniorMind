using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ExtensionMethods
{

    class Comparer<TSource,TKey> : IComparer<TSource>
    {

        private Func<TSource, TKey> keySelector;
        private  IComparer<TKey> comparer;

        public Comparer(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            this.keySelector = keySelector;
            this.comparer = comparer;
        }
        public int Compare([AllowNull] TSource a, [AllowNull] TSource b)
        {
            TKey keyA = keySelector(a);
            TKey keyB = keySelector(b);

            return comparer.Compare(keyA, keyB);
        }


        public int GetHashCode([DisallowNull] TSource obj)
        {
            return obj.GetHashCode();
        }
    }

}
