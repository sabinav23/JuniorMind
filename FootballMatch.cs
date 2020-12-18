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

        public FootballTeam HomeTeam
        {
            get
            {
                return homeTeam;
            }
            set
            {
                this.homeTeam = value;
            }
        }

        public FootballTeam AwayTeam
        {
            get
            {
                return awayTeam;
            }
            set
            {
                this.awayTeam = value;
            }
        }

        public MatchResult MatchResult
        {
            get
            {
                return matchResult;
            }
            set
            {
                this.matchResult = value;
            }
        }

        public void FindWinner()
        {
            const int pointsVictory = 3;
            const int pointsEqual = 1;
            if(this.MatchResult.HomeTeamResult > this.MatchResult.AwayTeamResult)
            {
                this.HomeTeam.IncreasePoints(pointsVictory);
            }
            if(this.MatchResult.HomeTeamResult == this.MatchResult.AwayTeamResult)
            {
                this.HomeTeam.IncreasePoints(pointsEqual);
                this.AwayTeam.IncreasePoints(pointsEqual);
            }
            this.AwayTeam.IncreasePoints(pointsVictory);
        }
    }
}
