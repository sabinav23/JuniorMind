using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONoop
{
    public class ChoiceFacts
    {
        [Fact]
        public void ReturnsFalseIfEmpty()
        {
            var test = new Choice(
                new Range('1', '9')
            );

            Assert.False(test.Match(""));
        }

        [Fact]
        public void ReturnsFalseIfNull()
        {
            var test = new Choice(
                new Range('1', '9')
            );

            Assert.False(test.Match(null));
        }
        
        [Fact]
        public void ReturnsTrueWhenValidRange()
        {
            var test = new Choice(
                new Range('1', '9')
            );

            Assert.True(test.Match("12345"));
        }

        [Fact]
        public void ReturnsTrueWhenExceedingRangeAndHasBoundry()
        {
            var test = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            Assert.False(test.Match("a9"));
        }

        [Fact]
        public void ReturnsTrueWhenFirstIsZeroAndHasValidChars()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            Assert.True(digit.Match("012345"));
        }

        [Fact]
        public void ReturnsTrueWhenInRange()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                digit,
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            Assert.True(hex.Match("012345"));
        }

        [Fact]
        public void ReturnsTrueWhenInRangeBoundry()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                digit,
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            Assert.True(hex.Match("A9"));
        }

        [Fact]
        public void ReturnsFalseWhenOutOfRangeBoundry()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                digit,
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            Assert.False(hex.Match("G9"));
        }

        [Fact]
        public void ReturnsFalseWhenNullAndMultiplePatterns()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                digit,
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            Assert.False(hex.Match(null));
        }

    }
}
