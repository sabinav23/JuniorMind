using System;
using System.Collections.Generic;
using System.Text;

namespace Football
{
    public class MatchResult
    {
        private int homeTeamResult;
        private int awayTeamResult;

        public MatchResult(int homeTeamResult, int awayTeamResult)
        {
            this.homeTeamResult = homeTeamResult;
            this.awayTeamResult = awayTeamResult;;
        }

        public int HomeTeamResult
        {
            get 
            {
                return homeTeamResult;
            }
            set
            {
                this.homeTeamResult = value;
            }
        }

        public int AwayTeamResult
        {
            get
            {
                return awayTeamResult;
            }
            set
            {
                this.awayTeamResult = value;
            }
        }

    }
}
