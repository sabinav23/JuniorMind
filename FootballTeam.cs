using Match;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football
{
    public class FootballTeam
    {
        private readonly string name;
        private int points;

        public FootballTeam(string name)
        {
            this.name = name;
        }

        public bool IsNameNullOrEmpty(string teamName)
        {
            return string.IsNullOrEmpty(teamName);
        }


        public string Name
        {
            get
            {
                return name;
            }
        }

        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                this.points = value;
            }
        }




    }
}
