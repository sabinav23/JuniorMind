using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONoop
{
    public class StringFacts
    {

        [Fact]
        public void WorksForSimpleString()
        {
            var a = new String();

            string test = Quoted("abc");

            Match match = new Match("", true);

            var bla = a.Match(test).RemainingText();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void CanContainEscapedReverseSolidus()
        {
            var a = new String();

            string test = Quoted("a \\b ");

            Match match = new Match("", true);

            var bla = a.Match(test).RemainingText();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void CanContainEscapedBackspace()
        {
            var a = new String();

            string test = Quoted(@"a \/ b");

            Match match = new Match("", true);

            var bla = a.Match(test).RemainingText();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void CanContainEscapedUnicodeCharacters()
        {
            var a = new String();

            string test = Quoted("a \\u26B6 \"");

            Match match = new Match("", true);

            var bla = a.Match(test).RemainingText();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }


        [Fact]
        public void Test()
        {
            var a = new String();

            string test = Quoted("\\u26B");

            Match match = new Match("\\u26B\"", true);

            var bla = a.Match(test).RemainingText();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void AllowesOnlyBackslash()
        {
            var a = new String();

            string test = Quoted(@"\\");

            Match match = new Match("", true);

            var bla = a.Match(test).RemainingText();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
