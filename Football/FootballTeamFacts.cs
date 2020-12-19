using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Football;

namespace FootballTeamsFacts
{
    public class TeamsFacts
    {
        [Fact]
        public void ReturnsTrueIfFirstTeamHasMorePoints()
        {
            FootballTeam firstTeam = new FootballTeam("Steaua");
            FootballTeam secondTeam = new FootballTeam("CFR");

            firstTeam.IncreasePoints(5);
            secondTeam.IncreasePoints(2);

            Assert.True(firstTeam.CompareTo(secondTeam));
        }
    }
}
