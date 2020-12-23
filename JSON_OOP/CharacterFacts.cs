using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONoop
{
    public class CharacterFacts
    {
        [Fact]
        public void VerifyFunctionReturnsRemainingTextAndTrueWhenMatched()
        {
            Character chr = new Character('0');
            Match match = new Match("", true);

            Assert.True(match.Success().Equals((chr.Match("0").Success())));
            Assert.True(match.RemainingText().Equals((chr.Match("0").RemainingText())));
        }
        
        [Fact]
        public void VerifyFunctionReturnsTextAndFalsWhenNull()
        {
            Character chr = new Character('0');

            Match match = new Match(null, false);

            Assert.True(match.Success().Equals(chr.Match(null).Success()));
            Assert.True(match.RemainingText() == chr.Match(null).RemainingText());
        }
        
        [Fact]
        public void VerifyFunctionReturnsTextAndFalseWhenEmpty()
        {
            Character chr = new Character('0');

            Match match = new Match("", false);

            Assert.True(match.Success().Equals((chr.Match("").Success())));
            Assert.True(match.RemainingText().Equals((chr.Match("").RemainingText())));
        }
    }
}
