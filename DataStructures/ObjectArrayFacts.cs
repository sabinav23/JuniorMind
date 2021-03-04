using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntArrayProject
{
    public class ObjectArrayFacts
    {
        [Fact]
        public void AddToArray()
        {
            var arr = new ObjectArray();
            arr.Add(5);
            arr.Add("ceva");
            arr.Add(6);
            arr.Add(7);
            arr.Add("altceva");
            arr.Add(9);

            Assert.True(arr[5].Equals(9));
        }

        [Fact]
        public void CountArrayElements()
        {
            var arr = new ObjectArray();
            arr.Add(5);
            arr.Add("ceva");
            arr.Add(6);
            arr.Add(7);
            arr.Add("altceva");
            arr.Add(9);

            Assert.Equal(6, arr.Count);
        }

        [Fact]
        public void ReturnsCorrectElementAtGivenIndex()
        {
            var arr = new ObjectArray();
            arr.Add(5);
            arr.Add("ceva");
            arr.Add(6);
            arr.Add(7);
            arr.Add("altceva");
            arr.Add(9);

            Assert.Equal("altceva", arr[4]);
        }

        [Fact]
        public void TheValueAtCurrentIndexIsChangedCorrectly()
        {
            var arr = new ObjectArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            arr[0] = "altceva";

            Assert.Equal("altceva", arr[0]);
        }

        [Fact]
        public void ReturnsTrueForElementInArray()
        {
            var arr = new ObjectArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            arr[0] = 2;

            Assert.True(arr.Contains(8));
        }

        [Fact]
        public void ReturnsFalseWhenElementIsNotInArray()
        {
            var arr = new ObjectArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            Assert.False(arr.Contains("altceva"));
        }

        [Fact]
        public void ReturnsIndexWhenElementIsInArray()
        {
            var arr = new ObjectArray();
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
            var arr = new ObjectArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            Assert.Equal(-1, arr.IndexOf("da"));
        }


        [Fact]
        public void AddElementAtGivenPosition()
        {
            var arr = new ObjectArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(9);


            arr.Insert(3, 10);

            Assert.Equal(9, arr[4]);
            Assert.Equal(5, arr.Count);
        }

        [Fact]
        public void ClearAllElements()
        {
            var arr = new ObjectArray();
            arr.Add(5);
            arr.Add(6);

            Assert.Equal(2, arr.Count);

            arr.Clear();

            Assert.Equal(0, arr.Count);
        }


        [Fact]
        public void RemoveFirstAppearance()
        {
            var arr = new ObjectArray();
            arr.Add(5);
            arr.Add("altceva");
            arr.Add(5);
            arr.Add(5);
            arr.Add(6);


            arr.Remove(5);

            Assert.Equal("altceva", arr[0]);
            Assert.Equal(4, arr.Count);
        }

        [Fact]
        public void RemoveElementAtIndex()
        {
            var arr = new ObjectArray();
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);
            arr.Add(10);


            arr.RemoveAt(2);

            Assert.Equal(9, arr[2]);
            Assert.Equal(4, arr.Count);
        }

        [Fact]
        public void ChangeElementValueToTen()
        {
            var arr = new ObjectArray();
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);
            arr.Add(10);

            arr.RemoveAt(2);

            Assert.Equal(9, arr[2]);
            Assert.Equal(4, arr.Count);
        }
    }
}
