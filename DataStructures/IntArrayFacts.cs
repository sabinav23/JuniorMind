﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntArrayProject
{
    public class IntArrayFacts
    {
        [Fact]
        public void AddNumberToArray()
        {
            var arr = new IntArray();
            arr.Add(5);

            Assert.True(arr.Element(0) == 5);
        }

        [Fact]
        public void CountArrayElements()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(6);

            Assert.Equal(2, arr.Count());
        }

        [Fact]
        public void ReturnsCorrectElementAtGivenIndex()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            Assert.Equal(7, arr.Element(2));
        }

        [Fact]
        public void TheValueAtCurrentIndexIsChangedCorrectly()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            arr.SetElement(0, 2);

            Assert.Equal(2, arr.Element(0));
        }

        [Fact]
        public void ReturnsTrueForElementInArray()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            arr.SetElement(0, 2);

            Assert.True(arr.Contains(8));
        }

        [Fact]
        public void ReturnsFalseWhenElementIsNotInArray()
        {
            var arr = new IntArray();
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
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            Assert.Equal(2, arr.IndexOf(7));
        }

        [Fact]
        public void ReturnsMinusOneWhenElementIsNotInArray()
        {
            var arr = new IntArray();
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
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);

            arr.Insert(2, 10);

            Assert.Equal(10, arr.Element(2));
        }

        [Fact]
        public void ClearAllElements()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(6);


            arr.Clear();

            Assert.Equal(0, arr.Element(0));
            Assert.Equal(0, arr.Element(1));
        }


        [Fact]
        public void RemoveFirstAppearance()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(6);
            arr.Add(5);
            arr.Add(5);
            arr.Add(6);


            arr.Remove(5);

            Assert.Equal(6, arr.Element(0));
        }

        [Fact]
        public void RemoveElementAtIndex()
        {
            var arr = new IntArray();
            arr.Add(6);
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);
            arr.Add(10);


            arr.RemoveAt(2);

            Assert.Equal(9, arr.Element(2));
        }

    }
}
