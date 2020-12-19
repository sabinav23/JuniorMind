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

        public bool DidHomeTeamWin()
        {
            return homeTeamResult > awayTeamResult;
        }

        public bool WasDraw()
        {
            return homeTeamResult == awayTeamResult;
        }


    }
}
