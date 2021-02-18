using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONoop
{
    public class ValueFacts
    {
        [Fact]
        public void AllowesString()
        {
            var a = new Value();

            string test = "\"125a\"";

            Match match = new Match("", true);

            var bla = a.Match(test).RemainingText();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void AllowesNumber()
        {
            var a = new Value();

            string test = " 125 ";

            Match match = new Match("", true);

            var bla = a.Match(test).RemainingText();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }


        [Fact]
        public void AllowesArray()
        {
            var a = new Value();

            string test = " [1, 2, 3, 4, 5] ";

            Match match = new Match("", true);

            var bla = a.Match(test).RemainingText();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void IsValidForElementComponent()
        {
            var a = new Value();

            string test = " { \"ceva\" : 5} ";

            Match match = new Match("", true);

            var bla = a.Match(test).RemainingText();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void AllowesTrueValue()
        {
            var a = new Value();

            string test = " true\n\n ";

            Match match = new Match("", true);

            var bla = a.Match(test).RemainingText();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void AllowesEmptyArray()
        {
            var a = new Value();

            string test = " [ ] ";

            Match match = new Match("", true);

            var bla = a.Match(test).RemainingText();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }
    }
}
