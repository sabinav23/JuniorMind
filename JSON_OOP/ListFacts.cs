using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONoop
{
    public class ListFacts
    {
        [Fact]
        public void VerifyFunctionReturnsEmptyStringAndTrueWhenInValidRangeAndValidSeparator()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            string test = "1,2,3";

            Match match = new Match("", true);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenInValidRangeAndValidSeparator()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            string test = "1,2,3,";

            Match match = new Match(",", true);

            var ceva = a.Match(test).RemainingText();
            var succi = a.Match(test).Success();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenInValidRangeAndText()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            string test = "1a";

            Match match = new Match("a", true);

            var ceva = a.Match(test).RemainingText();
            var succi = a.Match(test).Success();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenNoCharValid()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            string test = "abc";

            Match match = new Match("abc", true);

            var ceva = a.Match(test).RemainingText();
            var succi = a.Match(test).Success();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsEmptyAndTrueWhenEmptyString()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            string test = "";

            Match match = new Match("", true);

            var ceva = a.Match(test).RemainingText();
            var succi = a.Match(test).Success();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsNullAndTrueNull()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            string test = null;

            Match match = new Match(null, true);

            var ceva = a.Match(test).RemainingText();
            var succi = a.Match(test).Success();

            Assert.True(match.Success() == a.Match(test).Success());
            Assert.True(match.RemainingText() == a.Match(test).RemainingText());
        }

        [Fact]
        public void ReturnsEmptyAndTrueWhenConditionsMatch()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            string test = "1 ; 22  ;\n 333 \t; 22";

            Match match = new Match("", true);

            var ceva = list.Match(test).RemainingText();
            var succi = list.Match(test).Success();

            Assert.True(match.Success().Equals((list.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((list.Match(test).RemainingText())));
        }

        [Fact]
        public void ReturnsOnlyUnmatchedTextAndTrueWhenNotAllTextMatches()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            string test = "1 \n;";

            Match match = new Match(" \n;", true);

            var ceva = list.Match(test).RemainingText();
            var succi = list.Match(test).Success();

            Assert.True(match.Success().Equals((list.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((list.Match(test).RemainingText())));
        }

        [Fact]
        public void ReturnsAllTextAndTrueIfConditionsDoesNotMatch()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            string test = "abc";

            Match match = new Match("abc", true);

            var ceva = list.Match(test).RemainingText();
            var succi = list.Match(test).Success();

            Assert.True(match.Success().Equals((list.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((list.Match(test).RemainingText())));
        }
    }
}
