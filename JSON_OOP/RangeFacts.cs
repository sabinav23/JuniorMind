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
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenInValidRange()
        {
            Range range1 = new Range('a', 'f');

            string test = "abc";

            Match match = new Match("bc", true);

            Assert.True(match.Success().Equals((range1.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((range1.Match(test).RemainingText())));
        }
        
        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenCharacterIsBoundary()
        {
            Range range1 = new Range('a', 'f');

            string test = "fda";

            Match match = new Match("da", true);

            Assert.True(match.Success().Equals((range1.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((range1.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsFullTextAndFalseWhenExceedingBoundary()
        {
            Range range1 = new Range('a', 'f');

            string test = "1da";

            Match match = new Match("1da", false);

            Assert.True(match.Success().Equals((range1.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((range1.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsFalseWhenNull()
        {
            Range range1 = new Range('a', 'f');

            string test = null;

            Match match = new Match(test, false);

            Assert.True(match.Success() == range1.Match(test).Success());
            Assert.True(match.RemainingText() == range1.Match(test).RemainingText());
        }

        [Fact]
        public void VerifyFunctionReturnsFalseWhenEmpty()
        {
            Range range1 = new Range('a', 'f');

            string test = "";

            Match match = new Match("", false);

            Assert.True(match.Success().Equals((range1.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((range1.Match(test).RemainingText())));
        }
    }
}
