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
                teams = this.ChangeRanking(teams);
                return "Added with success!";
            }

            return "Not added!";
        }

        public string GetTeamAtGivenPosition(int position)
        {
            if (position < teams.Count)
            {
                return teams[position].ToString();
            }
            return "No team for the given position!";
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

            footballMatch.FindWinner();
            this.ChangeRanking(teams);
        }

        public List<FootballTeam> ChangeRanking(List<FootballTeam> teams)
        {
            for (int i = 0; i < teams.Count - 1; i++)
            {
                for (int j = i + 1; j < teams.Count; j++)
                {
                    if (!teams[i].CompareTo(teams[j]))
                    {
                        FootballTeam aux = teams[i];
                        teams[i] = teams[j];
                        teams[j] = aux;
                    }
                }
            }

            return teams;
        }

    }
}
