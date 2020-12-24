using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONoop
{
    public class SequenceFacts
    {
        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenValidChars()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            string text = "abcd";

            Match match = new Match("cd", true);

            Assert.True(match.Success().Equals((ab.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((ab.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsAllTextAndFalseWhenNotAllPattersMatch()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            string text = "ax";

            Match match = new Match("ax", false);

            Assert.True(match.Success().Equals((ab.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((ab.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsAllTextAndFalseWhenEmpty()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            string text = "";

            Match match = new Match("", false);

            Assert.True(match.Success().Equals((ab.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((ab.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsAllTextAndFalseWhenNull()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            string text = null;

            Match match = new Match(null, false);

            Assert.True(match.Success() == ab.Match(text).Success());
            Assert.True(match.RemainingText() == ab.Match(text).RemainingText());
        }

        [Fact]
        public void VerifyFunctionRemainingTextAndTrueWhenValidCharsAndMultipleSequences()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            string text = "abcd";

            Match match = new Match("d", true);

            Assert.True(match.Success().Equals((abc.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((abc.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionFullTextAndfalseWhenOutOfRangeCharsAndMultipleSequences()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            string text = "def";

            Match match = new Match("def", false);

            Assert.True(match.Success().Equals((abc.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((abc.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionFullTextAndfalseWhenOnlyOnePatterMatchedAndMultipleSequences()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            string text = "crd";

            Match match = new Match("crd", false);

            Assert.True(match.Success().Equals((abc.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((abc.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueForSequenceContainingChoiceAndInRangeValues()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            string text = "u1234";

            Match match = new Match("", true);

            Assert.True(match.Success().Equals((hexSeq.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((hexSeq.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueForSequenceContainingMoreInRangeValues()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            string text = "uabcdef";

            Match match = new Match("ef", true);

            Assert.True(match.Success().Equals((hexSeq.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((hexSeq.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueForSequenceContainingSpace()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            string text = "uB005 ab";

            Match match = new Match(" ab", true);

            Assert.True(match.Success().Equals((hexSeq.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((hexSeq.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsFullTextAndFalseWhenFirstCharDoesNotMatch()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            string text = "abc";

            Match match = new Match("abc", false);

            Assert.True(match.Success().Equals((hexSeq.Match(text).Success())));
            Assert.True(match.RemainingText().Equals((hexSeq.Match(text).RemainingText())));
        }

        [Fact]
        public void VerifyFunctionReturnsFullTextAndFalseWhenNullAndSequenceContainingChoice()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            string text = null;

            Match match = new Match(null, false);

            Assert.True(match.Success() == hexSeq.Match(text).Success());
            Assert.True(match.RemainingText() == hexSeq.Match(text).RemainingText());
        }
    }
}
