using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONoop
{
    public class CharacterFacts
    {
        [Fact]
        public void ReturnsTrueWhenMatched()
        {
            Character chr = new Character('0');

            Assert.True(chr.Match("0"));
        }

        [Fact]
        public void ReturnsFalseWhenNull()
        {
            Character chr = new Character('0');

            Assert.False(chr.Match(null));
        }

        [Fact]
        public void ReturnsFalseWhenEmpty()
        {
            Character chr = new Character('0');

            Assert.False(chr.Match(""));
        }

    }
}
