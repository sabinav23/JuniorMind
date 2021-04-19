using System;
using System.Collections.Generic;
using Xunit;

namespace Dictionary
{
    public class UnitTest1
    {
        [Fact]
        public void GetValueForKey()
        {
            var dictionary = new Dictionary<int, int>();
            dictionary.Add(50, 2);

            Assert.True(dictionary[50] == 2);
        }

        [Fact]
        public void SetValue()
        {
            var dictionary = new Dictionary<int, int>();
            dictionary.Add(50, 2);

            Assert.True(dictionary[50] == 2);

            dictionary[50] = 15;

            Assert.True(dictionary[50] == 15);
        }

        [Fact]
        public void AddValue()
        {
            var dictionary = new Dictionary<int, int>();
            dictionary.Add(50, 2);

            Assert.True(dictionary.ContainsKey(50));
        }

        [Fact]
        public void DictionaryContaisPair()
        {
            var dictionary = new Dictionary<int, int>();
            dictionary.Add(50, 2);
            var item = new KeyValuePair<int, int>(50, 2);

            Assert.True(dictionary.Contains(item));
        }

        [Fact]
        public void AddsAllPairs()
        {
            var dictionary = new Dictionary<int, int>();
            dictionary.Add(50, 2);
            dictionary.Add(20, 5);
            dictionary.Add(15, 8);
            dictionary.Add(95, 15);
            dictionary.Add(19, 85);

            Assert.True(dictionary.Count == 5);
        }

        [Fact]
        public void ClearArrays()
        {
            var dictionary = new Dictionary<int, int>();
            dictionary.Add(50, 2);
            dictionary.Add(20, 5);
            dictionary.Add(15, 8);
            dictionary.Add(95, 15);
            dictionary.Add(19, 85);

            dictionary.Clear();

            Assert.True(dictionary.Count == 0);
        }

        [Fact]
        public void FunctionReturnsTrueWhenArrayHasElementsAtEveryIndex()
        {
            var dictionary = new Dictionary<int, int>();
            dictionary.Add(50, 2);
            dictionary.Add(20, 5);
            dictionary.Add(15, 8);
            dictionary.Add(95, 15);
            dictionary.Add(19, 85);

            IEnumerator<KeyValuePair<int, int>> en = dictionary.GetEnumerator();

            Assert.True(en.MoveNext());
            Assert.Equal(8, en.Current.Value);
            Assert.True(en.MoveNext());
            Assert.Equal(85, en.Current.Value);
            Assert.True(en.MoveNext());
            Assert.Equal(5, en.Current.Value);
            Assert.True(en.MoveNext());
            Assert.Equal(2, en.Current.Value);
            Assert.True(en.MoveNext());
            Assert.Equal(15, en.Current.Value);
            Assert.False(en.MoveNext());
        }

        [Fact]
        public void CopyTo()
        {
            var dictionary = new Dictionary<int, int>();
            var arr = new KeyValuePair<int, int>[10];
            dictionary.Add(50, 2);
            dictionary.Add(20, 5);
            dictionary.Add(15, 8);
            dictionary.Add(95, 15);
            dictionary.Add(19, 85);

            dictionary.CopyTo(arr, 1);
            Assert.True(arr[0].Value == 8);
            Assert.True(arr[1].Value == 85);
            Assert.True(arr[2].Value == 5);
            Assert.True(arr[3].Value == 2);
            Assert.True(arr[4].Value == 15);

        }

        [Fact]
        public void RemoveElement()
        {
            var dictionary = new Dictionary<int, int>();
            dictionary.Add(50, 2);
            dictionary.Add(20, 5);
            dictionary.Add(15, 8);
            dictionary.Add(95, 15);
            dictionary.Add(19, 85);

            dictionary.Remove(19);
            Assert.True(dictionary.Count == 4);
            Assert.False(dictionary.ContainsKey(19));
            Assert.True(dictionary.ContainsKey(50));
            Assert.True(dictionary.ContainsKey(20));
            Assert.True(dictionary.ContainsKey(15));
            Assert.True(dictionary.ContainsKey(95));
        }

        [Fact]
        public void AddElementAfterRemove()
        {
            var dictionary = new Dictionary<int, int>();
            dictionary.Add(50, 2);
            dictionary.Add(20, 5);
            dictionary.Add(15, 8);
            dictionary.Add(95, 15);
            dictionary.Add(19, 85);

            dictionary.Remove(20);
            Assert.True(dictionary.Count == 4);
            Assert.False(dictionary.ContainsKey(20));
            Assert.True(dictionary.ContainsKey(50));
            Assert.True(dictionary.ContainsKey(19));
            Assert.True(dictionary.ContainsKey(15));

            dictionary.Add(16, 10);
            Assert.True(dictionary.ContainsKey(16));
        }

        [Fact]
        public void AddItemAfterRemove()
        {
            var dictionary = new Dictionary<int, int>();
            dictionary.Add(50, 2);
            dictionary.Add(20, 5);
            dictionary.Add(15, 8);
            dictionary.Add(95, 15);
            dictionary.Add(19, 85);

            var item = new KeyValuePair<int, int>(20, 5);
            dictionary.Remove(item);
            Assert.True(dictionary.Count == 4);
            Assert.False(dictionary.ContainsKey(20));
            Assert.True(dictionary.ContainsKey(50));
            Assert.True(dictionary.ContainsKey(19));
            Assert.True(dictionary.ContainsKey(15));

            dictionary.Add(16, 10);
            Assert.True(dictionary.ContainsKey(16));
            Assert.True(dictionary.Count == 5);

        }

        [Fact]
        public void RemoveItem()
        {
            var dictionary = new Dictionary<int, int>();
            dictionary.Add(50, 2);
            dictionary.Add(20, 5);
            dictionary.Add(15, 8);
            dictionary.Add(95, 15);
            dictionary.Add(19, 85);

            var item = new KeyValuePair<int, int>(19, 85);

            dictionary.Remove(item);
            Assert.True(dictionary.Count == 4);
            Assert.False(dictionary.ContainsKey(19));
            Assert.True(dictionary.ContainsKey(50));
            Assert.True(dictionary.ContainsKey(20));
            Assert.True(dictionary.ContainsKey(15));
            Assert.True(dictionary.ContainsKey(95));
        }

        [Fact]
        public void RemoveElementKeepValue()
        {
            var dictionary = new Dictionary<int, int>();
            dictionary.Add(50, 2);
            dictionary.Add(20, 5);
            dictionary.Add(15, 8);
            dictionary.Add(95, 15);
            dictionary.Add(19, 85);

            dictionary.Remove(19, out int value);
            Assert.True(dictionary.Count == 4);
            Assert.False(dictionary.ContainsKey(19));
            Assert.True(value == 85);
            Assert.True(dictionary.ContainsKey(50));
            Assert.True(dictionary.ContainsKey(20));
            Assert.True(dictionary.ContainsKey(15));
            Assert.True(dictionary.ContainsKey(95));
        }

        [Fact]
        public void TryGetValue()
        {
            var dictionary = new Dictionary<int, int>();
            dictionary.Add(50, 2);
            dictionary.Add(20, 5);
            dictionary.Add(15, 8);
            dictionary.Add(95, 15);
            dictionary.Add(19, 85);

            dictionary.TryGetValue(19, out int value);
            Assert.True(value == 85);

            dictionary.TryGetValue(78, out int val);
            Assert.True(val == 0);
        }

    }
}
