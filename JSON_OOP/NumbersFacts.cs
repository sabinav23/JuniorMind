using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONoop
{
    public class NumbersFacts
    {
        [Fact]
        public void CanBeZero()
        {
            var a = new Number();

            string test = "0";

            Match match = new Match("", true);

            var bla = a.Match(test).RemainingText();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void DoesNotContainLetters()
        {
            var a = new Number();

            string test = "a";

            Match match = new Match("a", false);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void CanHaveASingleDigit()
        {
            var a = new Number();

            string test = "7";

            Match match = new Match("", true);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void CanHaveMultipleDigits()
        {
            var a = new Number();

            string test = "78";

            Match match = new Match("", true);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void IsNotNull()
        {
            var a = new Number();

            string test = "";

            Match match = new Match("", false);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var a = new Number();

            string test = "";

            Match match = new Match("", false);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void DoesNotStartWithZero()
        {
            var a = new Number();

            string test = "07";

            Match match = new Match("7", true);

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void AllowesExponent()
        {
            var a = new Number();

            string test = "1e-14";

            Match match = new Match("", true);

            var bla = a.Match(test).RemainingText();

            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void CanBeRealNumber()
        {
            var a = new Number();

            string test = "12.56";

            Match match = new Match("", true);
            var bla = a.Match(test).RemainingText();
            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void CanBeNegative()
        {
            var a = new Number();

            string test = "-1256";

            Match match = new Match("", true);
            var bla = a.Match(test).RemainingText();
            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }

        [Fact]
        public void ConsumesComplexNumber()
        {
            var a = new Number();

            string test = "-15.2e-15";

            Match match = new Match("", true);
            var bla = a.Match(test).RemainingText();
            Assert.True(match.Success().Equals((a.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((a.Match(test).RemainingText())));
        }



    }
}
