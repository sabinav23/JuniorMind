using Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Football
{
    public class Ranking
    {
        private List<FootballTeam> teams = new List<FootballTeam>();

        public Ranking(List<FootballTeam> teams)
        {
            this.teams = teams;
        }


        public String AddTeamToRanking(FootballTeam footballTeam)
        {
            if (!footballTeam.IsNameNullOrEmpty(footballTeam.Name))
            {
                teams.Add(footballTeam);
                teams = SortTeamsByPoints(teams);
                return "Added with success!";
            }

            return "Not added!";
        }

        public FootballTeam GetTeamAtGivenPosition(int position)
        {
            return teams[position];
        }

        public string GetRankingOfGivenTeam(FootballTeam footballTeam)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Name.Equals(footballTeam.Name))
                {
                    return i.ToString();
                }
            }

            return "Your favorite team is not that cool!";
        }

        public void UpdateRanking(FootballMatch footballMatch)
        {
            foreach (FootballTeam team in teams)
            {
                if (team.Name.Equals(footballMatch.HomeTeam.Name))
                {
                    team.Points += footballMatch.MatchResult.HomeTeamResult;
                }
                else if (team.Name.Equals(footballMatch.AwayTeam.Name))
                {
                    team.Points += footballMatch.MatchResult.AwayTeamResult;
                }
                else
                {
                    Console.WriteLine("Teams are not in this competition");
                }
            }

            this.teams = SortTeamsByPoints(teams);
        }

        public List<FootballTeam> Teams
        {
            get
            {
                return Teams;
            }
        }

        public List<FootballTeam> SortTeamsByPoints(List<FootballTeam> footballTeams)
        {
            List<FootballTeam> sortedList = footballTeams.OrderBy(o => o.Points).ToList();
            return sortedList;
        }
    }
}
