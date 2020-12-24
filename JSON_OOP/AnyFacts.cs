using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONoop
{
    public class AnyFacts
    {
        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenInRange()
        {
            var e = new Any("eE");

            string test = "ea";

            Match match = new Match("a", true);

            Assert.True(match.Success().Equals((e.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((e.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenSearchedCharIsSecond()
        {
            var e = new Any("eE");

            string test = "Ea";

            Match match = new Match("a", true);

            Assert.True(match.Success().Equals((e.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((e.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsFullTextAndFalseWhenCharNotInString()
        {
            var e = new Any("eE");

            string test = "a";

            Match match = new Match("a", false);

            Assert.True(match.Success().Equals((e.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((e.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsFullTextAndFalseWhenNull()
        {
            var e = new Any("eE");

            string test = null;

            Match match = new Match(null, false);

            Assert.True(match.Success() == e.Match(test).Success());
            Assert.True(match.RemainingText() == e.Match(test).RemainingText());
        }

        [Fact]
        public void VerifyFunctionReturnsFullTextAndFalseWhenEmpty()
        {
            var e = new Any("eE");

            string test = "";

            Match match = new Match("", false);

            Assert.True(match.Success().Equals((e.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((e.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenSingInString()
        {
            var e = new Any("-+");

            string test = "+3";

            Match match = new Match("3", true);

            Assert.True(match.Success().Equals((e.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((e.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenSingIsFirstInString()
        {
            var e = new Any("-+");

            string test = "-2";

            Match match = new Match("2", true);

            Assert.True(match.Success().Equals((e.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((e.Match(test).RemainingText())));
        }

    }
}
