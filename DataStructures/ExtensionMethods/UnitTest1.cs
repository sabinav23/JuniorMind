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
        public void CatchesExceptionArgumentNullSource()
        {
            int[] elements = null;

            Exception exception = Assert.Throws<ArgumentNullException>(() => ExtensionMethod.All(elements, e => e < 10));
            Assert.Equal("Value cannot be null. (Parameter 'source')", exception.Message);
        }

        [Fact]
        public void CatchesExceptionArgumentNullPredicate()
        {
            int[] elements = new int[] { 1, 2, 3, 4, 5 };

            Exception exception = Assert.Throws<ArgumentNullException>(() => ExtensionMethod.All(elements, null));
            Assert.Equal("Value cannot be null. (Parameter 'predicate')", exception.Message);
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
        public void SelectMany()
        {
            var st1 = new Student(1, "John", 18);
            var st2 = new Student(2, "Steve", 15);
            var st3 = new Student(3, "Bill", 25);
            var st4 = new Student(4, "Ram", 20);

            var class1 = new List<Student> { st1, st3 };
            var class2 = new List<Student> { st2, st4 };
            var tch1 = new Teacher();
            var tch2 = new Teacher();
            tch1.Name = "Borindg";
            tch1.Students = class1;
            tch2.Name = "Cool";
            tch2.Students = class2;

            var teachers = new List<Teacher> { tch1, tch2 };

            var result = teachers.SelectMany(e => e.Students);

            IEnumerator<Student> en = result.GetEnumerator();

            Assert.True(en.MoveNext());
            Assert.Equal(st1, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(st3, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(st2, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(st4, en.Current);
            Assert.False(en.MoveNext());

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

        [Fact]
        public void Aggregate()
        {
            int[] elements = { 4, 8, 8, 3, 9, 0, 7, 8, 2 };

            var result = ExtensionMethod.Aggregate(elements, 0,  (a, b) => b % 2 == 0? a + 1: a);
            Assert.True(result == 6);
        }

        [Fact]
        public void Join()
        {
            int[] arr1 = { 4, 8, 9, 5, 10 };
            int[] arr2 = { 5, 12, 7, 9, 2 };

            var join = ExtensionMethod.Join(arr1, arr2, a => a, b => b, (a, b) => a);
            IEnumerator<int> en = (IEnumerator<int>)join.GetEnumerator();

            Assert.True(en.MoveNext());
            Assert.Equal(9, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(5, en.Current);
            Assert.False(en.MoveNext());
        }
        
        [Fact]
        public void Distinct()
        {
            int[] arr1 = { 4, 8, 4, 5, 9, 5, 10 };

            var comparer = EqualityComparer<int>.Default;
            var distinct = ExtensionMethod.Distinct(arr1, comparer);
            IEnumerator<int> en = (IEnumerator<int>)distinct.GetEnumerator();

            Assert.True(en.MoveNext());
            Assert.Equal(4, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(8, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(5, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(9, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(10, en.Current);
            Assert.False(en.MoveNext());
        }

        [Fact]
        public void Union()
        {
            int[] arr1 = { 4, 8, 4, 5, 9, 5, 10 };
            int[] arr2 = { 5, 8, 4, 5, 12, 51, 19 };

            var comparer = EqualityComparer<int>.Default;
            var union = ExtensionMethod.Union(arr1, arr2, comparer);
            IEnumerator<int> en = (IEnumerator<int>)union.GetEnumerator();

            Assert.True(en.MoveNext());
            Assert.Equal(4, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(8, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(5, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(9, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(10, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(12, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(51, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(19, en.Current);
            Assert.False(en.MoveNext());
        }

        [Fact]
        public void Intersect()
        {
            int[] arr1 = { 4, 8, 4, 5, 9, 5, 10 };
            int[] arr2 = { 5, 8, 4, 5, 12, 51, 19 };

            var comparer = EqualityComparer<int>.Default;
            var intersect = ExtensionMethod.Intersect(arr1, arr2, comparer);
            IEnumerator<int> en = (IEnumerator<int>)intersect.GetEnumerator();

            Assert.True(en.MoveNext());
            Assert.Equal(4, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(8, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(5, en.Current);
            Assert.False(en.MoveNext());
        }
        [Fact]
        public void Except()
        {
            int[] arr1 = { 4, 8, 4, 5, 9, 5, 10 };
            int[] arr2 = { 5, 8, 4, 5, 12, 51, 19 };

            var comparer = EqualityComparer<int>.Default;
            var except = ExtensionMethod.Except(arr1, arr2, comparer);
            IEnumerator<int> en = (IEnumerator<int>)except.GetEnumerator();

            Assert.True(en.MoveNext());
            Assert.Equal(9, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(10, en.Current);
            Assert.False(en.MoveNext());
        }

        [Fact]
        public void GroupBy()
        {
            List<Student> studentList = new List<Student>();
            var st1 = new Student(1, "John", 8.3);
            var st2 = new Student(2, "Steve", 4.9);
            var st3 = new Student(3, "Bill", 1.5);
            var st4 = new Student(4, "Ram", 4.3);

            studentList.Add(st1);
            studentList.Add(st2);
            studentList.Add(st3);
            studentList.Add(st4);

            var comparer = EqualityComparer<double>.Default;

            var result = ExtensionMethod.GroupBy(studentList,
                e => Math.Floor(e.Age),
                e => e.Age,
                (baseAge, ages) => new
                {
                    Key = baseAge,
                    Ages = ages
                },
                comparer);

            var en = result.GetEnumerator();
            Assert.True(en.MoveNext());
            var l = en.Current.Ages;
            var current = l.GetEnumerator();
            Assert.True(current.MoveNext());
            Assert.Equal(8.3, current.Current);
            Assert.True(en.MoveNext());
            var b = en.Current.Ages;
            var bCurrent = b.GetEnumerator();
            Assert.True(bCurrent.MoveNext());
            Assert.Equal(4.9, bCurrent.Current);
            Assert.True(bCurrent.MoveNext());
            Assert.Equal(4.3, bCurrent.Current);
            Assert.True(en.MoveNext());
            var c = en.Current.Ages;
            var cCurrent = c.GetEnumerator();
            Assert.True(cCurrent.MoveNext());
            Assert.Equal(1.5, cCurrent.Current);
            Assert.False(en.MoveNext());

        }

        [Fact]
        public void OrderBy()
        {
            string[] fruits = { "apricot", "orange", "banana", "mango", "apple", "grape", "strawberry" };
            var comparer = Comparer<string>.Default;



            var result = ExtensionMethod.OrderBy(fruits, e => e, comparer);
            var en = result.GetEnumerator();

            Assert.True(en.MoveNext());
            Assert.Equal("apple", en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal("apricot", en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal("banana", en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal("grape", en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal("mango", en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal("orange", en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal("strawberry", en.Current);
            Assert.False(en.MoveNext());
        }
        
        [Fact]
        public void ThenBy()
        {
           
            var comparer = Comparer<string>.Default;

            IList<Student> studentList = new List<Student>();

            var intComparer = Comparer<double>.Default;

            var st1 = new Student(1, "John", 18);
            var st2 = new Student(2, "Steve", 15);
            var st3 = new Student(3, "Bill", 25);
            var st4 = new Student(4, "Ram", 20);
            var st5 = new Student(5, "Ron", 19);
            var st6 = new Student(6, "Ra,", 18);

            studentList.Add(st1);
            studentList.Add(st2);
            studentList.Add(st3);
            studentList.Add(st4);
            studentList.Add(st5);
            studentList.Add(st6);

            var firstResult = ExtensionMethod.OrderBy(studentList, e => e.Name, comparer);
            var result = ExtensionMethod.ThenBy(firstResult, e => e.Age, intComparer);
            var en = result.GetEnumerator();

            Assert.True(en.MoveNext());
            Assert.Equal(st3, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(st1, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(st6, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(st4, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(st5, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(st2, en.Current);
            Assert.False(en.MoveNext());
        }   
    }
}
