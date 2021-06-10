using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods
{
    public static class ExtensionMethod
    {

        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            EnsureNotNull(source, nameof(source));
            EnsureNotNull(predicate, nameof(predicate));

            foreach (var s in source)
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
            EnsureNotNull(source, nameof(source));

            foreach (var s in source)
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
            EnsureNotNull(source, nameof(source));
            EnsureNotNull(predicate, nameof(predicate));

            foreach (var s in source)
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
            EnsureNotNull(source, nameof(source));
            EnsureNotNull(selector, nameof(selector));

            foreach (var s in source)
            {
                yield return selector(s);
            }

        }
        
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            EnsureNotNull(source, nameof(source));
            EnsureNotNull(selector, nameof(selector));

            foreach (TSource item in source)
            {
                foreach (TResult result in selector(item))
                {
                    yield return result;
                }
            }
        }
        
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            EnsureNotNull(source, nameof(source));
            EnsureNotNull(source, nameof(predicate));

            foreach (var s in source)
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
            EnsureNotNull(source, nameof(source));
            EnsureNotNull(keySelector, nameof(keySelector));
            EnsureNotNull(elementSelector, nameof(elementSelector));
            var dictionary = new Dictionary<TKey, TElement>();

            foreach (var s in source)
            {
                TKey key = keySelector(s);
                EnsureNotNull(key, nameof(key));

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
            EnsureNotNull(first, nameof(first));
            EnsureNotNull(second, nameof(second));

            var fEn = first.GetEnumerator();
            var sEn = second.GetEnumerator();

            while (fEn.MoveNext() && sEn.MoveNext())
            {
                yield return resultSelector(fEn.Current, sEn.Current);
            }
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            EnsureNotNull(source, nameof(source));
            EnsureNotNull(seed, nameof(seed));
            EnsureNotNull(func, nameof(func));

            var accumulator = seed;
            foreach (var s in source)
            {
                accumulator = func(accumulator, s);
            }

            return accumulator;
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            EnsureNotNull(outer, nameof(outer));
            EnsureNotNull(inner, nameof(inner));
            EnsureNotNull(outerKeySelector, nameof(outerKeySelector));
            EnsureNotNull(innerKeySelector, nameof(innerKeySelector));
            EnsureNotNull(resultSelector, nameof(resultSelector));

            foreach (var o in outer)
            {
                foreach (var i in inner)
                {
                    TKey outerKey = outerKeySelector(o);
                    TKey innerKey = innerKeySelector(i);
                    if (outerKey.Equals(innerKey))
                    {
                        yield return resultSelector(o, i);
                    }
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(
            this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            EnsureNotNull(source, nameof(source));

            var hashset = new HashSet<TSource>(source, comparer);

            return hashset;
        }

        public static IEnumerable<TSource> Union<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            EnsureNotNull(first, nameof(first));
            EnsureNotNull(second, nameof(second));

            var firstH = new HashSet<TSource>(first, comparer);
            var secondH = new HashSet<TSource>(second, comparer);
            var result = new HashSet<TSource>();

            return firstH.Union(second, comparer);
        }

        public static IEnumerable<TSource> Intersect<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            EnsureNotNull(first, nameof(first));
            EnsureNotNull(second, nameof(second));

            var firstH = new HashSet<TSource>(first, comparer);
            var secondH = new HashSet<TSource>(second, comparer);

            firstH.IntersectWith(secondH);

            return firstH;
        }

        public static IEnumerable<TSource> Except<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            EnsureNotNull(first, nameof(first));
            EnsureNotNull(second, nameof(second));

            var firstH = new HashSet<TSource>(first, comparer);
            var secondH = new HashSet<TSource>(second, comparer);

            firstH.ExceptWith(secondH);

            return firstH;
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            EnsureNotNull(source, nameof(source));
            EnsureNotNull(keySelector, nameof(keySelector));
            EnsureNotNull(elementSelector, nameof(elementSelector));

            var dictionary = new Dictionary<TKey, TElement>(comparer);
            var results = new List<TResult>();
            foreach (TSource s in source)
            {
                TKey key = keySelector(s);
                EnsureNotNull(key, nameof(key));

                TElement element = elementSelector(s);
                dictionary.Add(key, element);

                yield return resultSelector(key, dictionary.Values);
            }
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            EnsureNotNull(source, nameof(source));
            EnsureNotNull(keySelector, nameof(keySelector));
            var newComparer = new Comparer<TSource, TKey>(keySelector, comparer);

            return new OrderedEnum<TSource>(source, newComparer);
        }

        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
            this IOrderedEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            EnsureNotNull(source, nameof(source));
            EnsureNotNull(keySelector, nameof(keySelector));

            return source.CreateOrderedEnumerable(keySelector, comparer, false);
        }

        private static void EnsureNotNull<T>(T parameter, string name)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
