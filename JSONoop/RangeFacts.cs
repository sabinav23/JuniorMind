using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JSONoop;

namespace JSONoop
{
    public class RangeFacts
    {
        [Fact]
        public void ReturnsTrueWhenInValidRange()
        {
            Range range1 = new Range('a', 'f');

            string test = "abc";

            Assert.True(range1.Match(test));
        }

        [Fact]
        public void ReturnsTrueWhenCharacterIsBoundary()
        {
            Range range1 = new Range('a', 'f');

            string test = "fda";

            Assert.True(range1.Match(test));
        }

        [Fact]
        public void ReturnsFalseWhenExceedingBoundary()
        {
            Range range1 = new Range('a', 'f');

            string test = "1da";

            Assert.False(range1.Match(test));
        }

        [Fact]
        public void ReturnsFalseWhenNull()
        {
            Range range1 = new Range('a', 'f');

            string test = null;

            Assert.False(range1.Match(test));
        }

        [Fact]
        public void ReturnsFalseWhenEmpty()
        {
            Range range1 = new Range('a', 'f');

            string test = "";

            Assert.False(range1.Match(test));
        }
    }
}
