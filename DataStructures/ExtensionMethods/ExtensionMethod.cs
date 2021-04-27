using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    public static class ExtensionMethod
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            foreach (TSource s in source)
            {
                if (!predicate(s))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            foreach (TSource s in source)
            {
                if (predicate(s))
                {
                    return true;
                }
            }

            return false;
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            foreach (TSource s in source)
            {
                if (predicate(s))
                {
                    return s;
                }
            }

            throw new InvalidOperationException();
        }
        
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException();
            }

            foreach (TSource s in source)
            {
                yield return selector(s);
            }

        }
        /*
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
       
        */
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            foreach (TSource s in source)
            {
                if (predicate(s))
                {
                    yield return s;
                }
            }

        }
        
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            if (source == null || keySelector == null || elementSelector == null)
            {
                throw new ArgumentNullException();
            }
            var dictionary = new Dictionary<TKey, TElement>();

            foreach(TSource s in source)
            {
                TKey key= keySelector(s);
                if ( key == null)
                {
                    throw new ArgumentNullException();
                }

                if (dictionary.ContainsKey(key))
                {
                    throw new ArgumentException();
                }

                TElement element = elementSelector(s);
                dictionary.Add(key, element);
            }

            return dictionary;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }

            var fEn = first.GetEnumerator();
            var sEn = second.GetEnumerator();

            while (fEn.MoveNext() && sEn.MoveNext())
            {
                yield return resultSelector(fEn.Current, sEn.Current);
            }
        } 

    }
}
