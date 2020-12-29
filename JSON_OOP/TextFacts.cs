using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONoop
{
    public class TextFacts
    {
        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenTextMachedPrefix()
        {
            var text = new Text("true");

            string test = "true";

            Match match = new Match("", true);

            Assert.True(match.Success().Equals((text.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((text.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenTextMachedPrefixAndHasRemainingChars()
        {
            var text = new Text("true");

            string test = "trueXE";

            Match match = new Match("XE", true);

            Assert.True(match.Success().Equals((text.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((text.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsFullTextAndFalseWhenTextDoesNotMatchPrefix()
        {
            var text = new Text("true");
            var falseText = new Text("false");

            string test = "false";

            Match match = new Match("false", false);

            Assert.True(match.Success().Equals((text.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((text.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsFullTextAndFalseWhenTextDoesNotMatchFullPrefix()
        {
            var text = new Text("true");

            string test = "truVE";

            Match match = new Match("truVE", false);

            Assert.True(match.Success().Equals((text.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((text.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsFullTextAndFalseWhenEmpty()
        {
            var text = new Text("true");
            var falseText = new Text("false");

            string test = "";

            Match match = new Match("", false);

            Assert.True(match.Success().Equals((text.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((text.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsFullTextAndFalseWhenNull()
        {
            var text = new Text("true");
            var falseText = new Text("false");

            string test = null;

            Match match = new Match(null, false);

            Assert.True(match.Success() == text.Match(test).Success());
            Assert.True(match.RemainingText() == text.Match(test).RemainingText());
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenPrefixIsEmpty()
        {
            var empty = new Text("");

            string test = "true";

            Match match = new Match("true", true);

            Assert.True(match.Success().Equals((empty.Match(test).Success())));
            Assert.True(match.RemainingText().Equals((empty.Match(test).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsFullTextAndFalseWhenPrefixIsEmptyAndTextIsNull()
        {
            var empty = new Text("");

            string test = null;

            Match match = new Match(null, false);

            Assert.True(match.Success() == empty.Match(test).Success());
            Assert.True(match.RemainingText() == empty.Match(test).RemainingText());
        }


    }
}
