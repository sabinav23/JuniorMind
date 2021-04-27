using System;
using System.Collections.Generic;
using Xunit;

namespace ExtensionMethods
{
    public class UnitTest1
    {
        [Fact]
        public void ReturnTrueWhenAllMatch()
        {
            int[] elements = new int[] { 1, 2, 3, 4, 5 };


            Assert.True(ExtensionMethod.All(elements, e => e < 10));
        }

        [Fact]
        public void ReturnFalseWhenNotAllMatch()
        {
            int[] elements = new int[] { 1, 2, 3, 15, 5 };


            Assert.False(ExtensionMethod.All(elements, e => e < 10));
        }

        [Fact]
        public void ReturnTrueWhenOneMatches()
        {
            int[] elements = new int[] { 15, 15, 5, 15, 15 };


            Assert.True(ExtensionMethod.Any(elements, e => e < 10));
        }

        [Fact]
        public void ReturnFalseWhenNoneMatch()
        {
            int[] elements = new int[] { 11, 12, 13, 14, 15 };


            Assert.False(ExtensionMethod.Any(elements, e => e < 10));
        }

        [Fact]
        public void ReturnMatchingNumber()
        {
            int[] elements = new int[] { 11, 12, 5, 14, 15 };

            int first = ExtensionMethod.First(elements, e => e < 10);
            Assert.True(first == 5);
        }

        [Fact]
        public void CatchesException()
        {
            int[] elements = new int[] { 11, 12, 15, 14, 15 };

            Exception exception = Assert.Throws<InvalidOperationException>(() => ExtensionMethod.First(elements, e => e < 10));
            Assert.Equal("Operation is not valid due to the current state of the object.", exception.Message);
        }

        [Fact]
        public void ReturnsNewElements()
        {
            string[] fruits = { "apple", "banana", "mango", "orange" };

            IEnumerable<string> str = ExtensionMethod.Select(fruits, e => e.ToUpper());
            IEnumerator<string> en = str.GetEnumerator();

            Assert.True(en.MoveNext());
            Assert.Equal("APPLE", en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal("BANANA", en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal("MANGO", en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal("ORANGE", en.Current);
            Assert.False(en.MoveNext());
        }

        [Fact]
        public void HasCorrectValues()
        {
            int[] elements = new int[] { 61, 42, 85, 68, 79 };

            Dictionary<int, int> dict = ExtensionMethod.ToDictionary(elements, e => e % 10, e => e);
            Assert.True(dict.ContainsKey(5));
            Assert.False(dict.ContainsValue(5));
        }

        [Fact]
        public void ZipHasCorrectValues()
        {
            string[] arr1 = new string[] { "apa", "soarele", "vremea" };
            string[] arr2 = new string[] { "albastra", "galben", "minunata" };

            var zip = ExtensionMethod.Zip(arr1, arr2, (a, b) => a + " e " + b);
            IEnumerator<string> en = zip.GetEnumerator();

            Assert.True(en.MoveNext());
            Assert.Equal("apa e albastra", en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal("soarele e galben", en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal("vremea e minunata", en.Current);
            Assert.False(en.MoveNext());
        }
    }
}
