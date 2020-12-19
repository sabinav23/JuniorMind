using Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Football
{
    public class Ranking
    {
        private FootballTeam[] teams = new FootballTeam[0];

        public void AddTeam(FootballTeam footballTeam)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[teams.Length - 1] = footballTeam;
            ChangeRanking();

        }

        public FootballTeam GetTeamAtGivenPosition(int position)
        {
            return teams[position];
        }

        public int GetRanking(FootballTeam footballTeam)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].Equals(footballTeam))
                {
                    return i;
                }
            }

            return -1;
        }

        public void UpdateRanking(FootballMatch footballMatch)
        {

            footballMatch.UpdatePoints();
            ChangeRanking();
        }

        private void ChangeRanking()
        {
            for (int i = 0; i < teams.Length - 1; i++)
            {
                bool swaped = false;
                for (int j = 0; j < teams.Length - i - 1; j++)
                {
                    if (!teams[j].CompareTo(teams[j + 1]))
                    {
                        Swap(teams, j, j + 1);
                        swaped = true;
                    }
                }
                if (!swaped)
                {
                    return;
                }
            }
        }

        private void Swap(FootballTeam[] teams, int i, int j)
        {
            FootballTeam aux = teams[i];
            teams[i] = teams[j];
            teams[j] = aux;
        }
    }
}
