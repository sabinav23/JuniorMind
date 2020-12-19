using Football;
using System;
using System.Collections.Generic;
using System.Text;

namespace Match
{
    public class FootballMatch
    {
        private FootballTeam homeTeam;
        private FootballTeam awayTeam;
        private MatchResult matchResult;

        public FootballMatch(FootballTeam homeTeam, FootballTeam awayTeam, MatchResult matchResult)
        {
            this.homeTeam = homeTeam;
            this.awayTeam = awayTeam;
            this.matchResult = matchResult;
        }


        public void UpdatePoints()
        {
            const int pointsVictory = 3;
            const int pointsEqual = 1;
            if(matchResult.DidHomeTeamWin())
            {
                homeTeam.IncreasePoints(pointsVictory);
            }
            if(matchResult.WasDraw())
            {
                homeTeam.IncreasePoints(pointsEqual);
                awayTeam.IncreasePoints(pointsEqual);
            }
            awayTeam.IncreasePoints(pointsVictory);
        }
    }
}
