using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONoop
{
    
    public class ChoiceFacts
    {
        [Fact]
        public void VerifyFunctionReturnsFalseIfEmpty()
        {
            var test = new Choice(
                new Range('1', '9')
            );

            string text = "";

            Match match = new Match("", false);

            Assert.True(match.Success().Equals((test.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((test.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsFalseIfNull()
        {
            var test = new Choice(
                new Range('1', '9')
            );

            string text = null;

            Match match = new Match(null, false);

            Assert.True(match.Success() == test.Match(text).Success());
            Assert.True(match.RemainingText() == test.Match(text).RemainingText());
        }
        
        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenValidRange()
        {
            var test = new Choice(
                new Range('1', '9')
            );

            string text = "12345";

            Match match = new Match("2345", true);

            Assert.True(match.Success().Equals((test.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((test.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsFullTextAndFalseWhenExceedingRangeAndHasBoundry()
        {
            var test = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            string text = "a2345";

            Match match = new Match("a2345", false);

            Assert.True(match.Success().Equals((test.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((test.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenFirstIsZeroAndHasValidChars()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            string text = "012345";

            Match match = new Match("12345", true);

            Assert.True(match.Success().Equals((digit.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((digit.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenInRange()
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

            string text = "A12345";

            Match match = new Match("12345", true);

            Assert.True(match.Success().Equals((hex.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((hex.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenInRangeAndBoundry()
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

            string text = "F9";

            Match match = new Match("9", true);

            Assert.True(match.Success().Equals((hex.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((hex.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsFullTextAndFalseWhenOutOfRangeBoundry()
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

            string text = "G12345";

            Match match = new Match("G12345", false);

            Assert.True(match.Success().Equals((hex.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((hex.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsFalseWhenNullAndMultiplePatterns()
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

            string text = null;

            Match match = new Match(null, false);

            Assert.True(match.Success() == hex.Match(text).Success());
            Assert.True(match.RemainingText() == hex.Match(text).RemainingText());
        }

    }
}
