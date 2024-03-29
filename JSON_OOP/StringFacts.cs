﻿using System;
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

            string test = Quoted("a \\u26B6 \\\"");

            Match match = new Match("", true);

            var bla = a.Match(test).RemainingText();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }


        [Fact]
        public void IncompleteHex()
        {
            var a = new String();

            string test = Quoted("a \\u12 ");

            Match match = new Match("\"a \\u12 \"", false);

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
