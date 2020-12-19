using Match;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Football
{
    public class MatchResultFacts
    {
        [Fact]
        public void ReturnsTrueIfHomeTeamHasAHigherScore()
        {
            MatchResult matchResult = new MatchResult(5, 1);

            Assert.True(matchResult.DidHomeTeamWin());
        }

        [Fact]
        public void ReturnsTrueIfDraw()
        {
            MatchResult matchResult = new MatchResult(5, 5);

            Assert.True(matchResult.WasDraw());
        }

        [Fact]
        public void ReturnsFalseIfHomeTeamHasLowerScore()
        {
            MatchResult matchResult = new MatchResult(1, 5);

            Assert.False(matchResult.DidHomeTeamWin());
        }

        [Fact]
        public void ReturnsFalseIfNotDraw()
        {
            MatchResult matchResult = new MatchResult(1, 5);

            Assert.False(matchResult.WasDraw());
        }
    }
}
