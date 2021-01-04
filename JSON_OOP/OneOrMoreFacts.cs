using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONoop
{
    public class OneOrMoreFacts
    {
        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenInValidRange()
        {
            var a = new OneOrMore(new Range('0', '9'));

            string test = "123";

            Match match = new Match("", true);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenInValidRangeAndChar()
        {
            var a = new OneOrMore(new Range('0', '9'));

            string test = "1a";

            Match match = new Match("a", true);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndFalseWhenOutOfRange()
        {
            var a = new OneOrMore(new Range('0', '9'));

            string test = "bc";

            Match match = new Match("bc", false);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndFalseWhenEmpty()
        {
            var a = new OneOrMore(new Range('0', '9'));

            string test = "";

            Match match = new Match("", false);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenNull()
        {
            var a = new OneOrMore(new Range('0', '9'));

            string test = null;

            Match match = new Match(null, false);

            Assert.True(match.Success() == a.Match(test).Success());
            Assert.True(match.RemainingText() == a.Match(test).RemainingText());
        }
    }
}
