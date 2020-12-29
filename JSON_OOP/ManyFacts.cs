using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONoop
{
    public class ManyFacts
    {
        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenInValidRange()
        {
            var a = new Many(new Character('a'));

            string test = "abc";

            Match match = new Match("bc", true);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenMultipleInRangeChars()
        {
            var a = new Many(new Character('a'));

            string test = "aaaaabc";

            Match match = new Match("bc", true);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenCharNotInText()
        {
            var a = new Many(new Character('a'));

            string test = "bc";

            Match match = new Match("bc", true);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenEmpty()
        {
            var a = new Many(new Character('a'));

            string test = "";

            Match match = new Match("", true);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenNull()
        {
            var a = new Many(new Character('a'));

            string test = null;

            Match match = new Match(null, true);

            Assert.True(match.Success() == a.Match(test).Success());
            Assert.True(match.RemainingText() == a.Match(test).RemainingText());
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextWhenInRange()
        {
            var a = new Many(new Range('0', '9'));

            string test = "12345super12345";

            Match match = new Match("super12345", true);

            Assert.True(match.Success() == a.Match(test).Success());
            Assert.True(match.RemainingText() == a.Match(test).RemainingText());
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextWhenTextNotInRange()
        {
            var a = new Many(new Range('0', '9'));

            string test = "super";

            Match match = new Match("super", true);

            Assert.True(match.Success() == a.Match(test).Success());
            Assert.True(match.RemainingText() == a.Match(test).RemainingText());
        }
    }

}
