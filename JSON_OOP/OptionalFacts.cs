using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONoop
{
    public class OptionalFacts
    {
        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueIfHasChar()
        {
            var a = new Optional(new Character('a'));

            string test = "abc";

            Match match = new Match("bc", true);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueIfHasMultipleChars()
        {
            var a = new Optional(new Character('a'));

            string test = "aabc";

            Match match = new Match("abc", true);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueIfHasNoCharMatching()
        {
            var a = new Optional(new Character('a'));

            string test = "bc";

            Match match = new Match("bc", true);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueIfEmpty()
        {
            var a = new Optional(new Character('a'));

            string test = "";

            Match match = new Match("", true);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueIfNull()
        {
            var a = new Optional(new Character('a'));

            string test = null;

            Match match = new Match(null, true);

            Assert.True(match.Success() == a.Match(test).Success());
            Assert.True(match.RemainingText() == a.Match(test).RemainingText());
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenCharIsSign()
        {
            var a = new Optional(new Character('-'));

            string test = "-aabc";

            Match match = new Match("aabc", true);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }
    }
}
