using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntArrayProject
{
    public class SortedIntArrayFacts
    {
        [Fact]
        public void AddNumberToArray()
        {
            var arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(5);
            arr.Add(6);
            arr.Add(9);
            arr.Add(8);
            arr.Add(7);

            Assert.True(arr[3] == 7);
        }

        [Fact]
        public void CountArrayElements()
        {
            var arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(5);
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            Assert.Equal(8, arr.Count);
        }

        [Fact]
        public void ReturnsCorrectElementAtGivenIndex()
        {
            var arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(7);
            arr.Add(6);
            arr.Add(9);
            arr.Add(8);

            Assert.Equal(9, arr[4]);
        }

        [Fact]
        public void TheValueAtCurrentIndexIsChangedCorrectly()
        {
            var arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            arr.Insert(0, 2);

            Assert.Equal(2, arr[0]);
            Assert.Equal(6, arr.Count);


        }

        [Fact]
        public void TheValueAtCurrentIndexDoesNotChangeWhenInsertedAtWrongPosition()
        {
            var arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            arr.Insert(0, 6);

            Assert.False(6 == arr[0]);
        }


        [Fact]
        public void ReturnsFalseWhenElementIsNotInArray()
        {
            var arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            Assert.False(arr.Contains(2));
        }

        [Fact]
        public void ReturnsIndexWhenElementIsInArray()
        {
            var arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            Assert.Equal(4, arr.IndexOf(9));
        }

        [Fact]
        public void ReturnsMinusOneWhenElementIsNotInArray()
        {
            var arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            Assert.Equal(-1, arr.IndexOf(2));
        }


        [Fact]
        public void AddElementAtGivenPosition()
        {
            var arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(9);


            arr.Insert(4, 10);

            Assert.Equal(10, arr[4]);
            Assert.Equal(5, arr.Count);
        }

        [Fact]
        public void ClearAllElements()
        {
            var arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(6);

            Assert.Equal(2, arr.Count);

            arr.Clear();

            Assert.Equal(0, arr.Count);
        }


        [Fact]
        public void RemoveFirstAppearance()
        {
            var arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(7);
            arr.Add(6);
            arr.Add(9);
            arr.Add(8);


            arr.Remove(5);

            Assert.Equal(6, arr[0]);
            Assert.Equal(4, arr.Count);
        }

        [Fact]
        public void RemoveElementAtIndex()
        {
            var arr = new SortedIntArray();
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);
            arr.Add(10);


            arr.RemoveAt(2);

            Assert.Equal(9, arr[2]);
        }


        [Fact]
        public void InsertUsingIndexersDoesNotWorkForIncorrectIndex()
        {
            var arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            arr[0] = 10;

            Assert.Equal(5, arr[0]);
        }
    }
}
