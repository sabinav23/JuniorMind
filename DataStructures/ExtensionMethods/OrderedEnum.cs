using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods
{
    class OrderedEnum<TSource> : IOrderedEnumerable<TSource> 
    {
        IEnumerable<TSource> source;
        IComparer<TSource> comparer;
        public OrderedEnum(IEnumerable<TSource> source, IComparer<TSource> comparer){
            this.source = source;
            this.comparer = comparer;
        }
        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(Func<TSource, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            var keyComparer = new Comparer<TSource, TKey>(keySelector, comparer);

            return new OrderedEnum<TSource>(source, new MultipleComparer<TSource>(this.comparer, keyComparer));
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            var sourceList = source.ToList();

            sourceList.Sort(comparer);

            foreach(var s in sourceList)
            {
                yield return s;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
