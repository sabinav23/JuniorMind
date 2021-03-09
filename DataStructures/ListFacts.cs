using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntArrayProject
{
    public class ListFacts
    {
            [Fact]
            public void AddToArray()
            {
                var arr = new List<int>();
                arr.Add(5);
                arr.Add(6);
                arr.Add(7);
                arr.Add(9);

                Assert.True(arr[2].Equals(7));
            }
        
            [Fact]
            public void CountArrayElements()
            {
            var arr = new List<string>();

                arr.Add("ceva");
                arr.Add("altceva");

                Assert.Equal(2, arr.Count);
            }
        
            [Fact]
            public void ReturnsCorrectElementAtGivenIndex()
            {
            var arr = new List<string>();

                arr.Add("ceva");
                arr.Add("altceva");

                Assert.Equal("altceva", arr[1]);
            }
        
            [Fact]
            public void TheValueAtCurrentIndexIsChangedCorrectly()
            {
                var arr = new List<int>();
                arr.Add(6);
                arr.Add(7);
                arr.Add(8);
                arr.Add(9);

                arr[0] = 15;

                Assert.Equal(15, arr[0]);
            }

            [Fact]
            public void ReturnsTrueForElementInArray()
            {
            var arr = new List<int>();
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
            var arr = new List<string>();
                arr.Add("da");
                arr.Add("nu");
                arr.Add("poate");
                arr.Add("sigur");
                arr.Add("never");

            Assert.False(arr.Contains("niciodata"));
            }

            [Fact]
            public void ReturnsIndexWhenElementIsInArray()
            {
            var arr = new List<int>();
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
                var arr = new List<int>();
                arr.Add(5);
                arr.Add(6);
                arr.Add(7);
                arr.Add(8);
                arr.Add(9);

                Assert.Equal(-1, arr.IndexOf(96));
            }


            [Fact]
            public void AddElementAtGivenPosition()
            {
            var arr = new List<int>();
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
            var arr = new List<int>();
                arr.Add(5);
                arr.Add(6);

                Assert.Equal(2, arr.Count);

                arr.Clear();

                Assert.Equal(0, arr.Count);
            }


            [Fact]
            public void RemoveFirstAppearance()
            {
                IList<int> arr = new List<int>();
                arr.Add(5);
                arr.Add(6);
                arr.Add(5);
                arr.Add(8);


                bool success = arr.Remove(5);
                Assert.True(success);
                Assert.Equal(6, arr[0]);
            }

            [Fact]
            public void RemoveElementAtIndex()
            {
                var arr = new List<int>();
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
            public void FunctionReturnsTrueWhenArrayHasElementsAtEveryIndex()
            {
                IList<int> arr = new List<int>();
                arr.Add(6);
                arr.Add(7);
                arr.Add(8);
                arr.Add(9);

                IEnumerator<int> en = arr.GetEnumerator();

                Assert.True(en.MoveNext());
                Assert.Equal(6, en.Current);
                Assert.True(en.MoveNext());
                Assert.Equal(7, en.Current);
                Assert.True(en.MoveNext());
                Assert.Equal(8, en.Current);
                Assert.True(en.MoveNext());
                Assert.Equal(9, en.Current);
                Assert.False(en.MoveNext());
            }

            [Fact]
            public void ReturnsFalseWhenArrayIsEmpty()
            {
                IList<int> arr = new List<int>();
                IEnumerator<int> en = arr.GetEnumerator();
                Assert.False(en.MoveNext());
            }

            [Fact]
            public void ReturnsTrueForFirstElement()
            {
                IList<int> arr = new List<int>();
                arr.Add(6);

                IEnumerator<int> en = arr.GetEnumerator();

                Assert.True(en.MoveNext());
                Assert.Equal(6, en.Current);
                Assert.False(en.MoveNext());
            }

            [Fact]
            public void CopyToMethodHasExpectedResult()
            {
                var arr = new List<int>();
                arr.Add(6);
                arr.Add(7);
                arr.Add(8);
                arr.Add(9);
                arr.Add(10);

                var intArrIndex = 5;
                var intArrLength = arr.Count + intArrIndex;

                var intArr = new int[intArrLength];
                arr.CopyTo(intArr, intArrIndex);

                Assert.Equal(10, intArr[9]);
                Assert.Equal(5, arr.Count);
            }
    }
}
