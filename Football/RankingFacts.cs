using Match;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Football
{
    public class RankingFacts
    {

        [Fact]
        public void CanAddTeamToRanking()
        {
            
            FootballTeam teamOne = new FootballTeam("Steaua");
            FootballTeam teamTwo = new FootballTeam("");

            Ranking ranking = new Ranking();
            ranking.AddTeam(teamOne);
            
            Assert.Equal(teamOne, ranking.GetTeamAtGivenPosition(0));         
        }

        [Fact]
        public void GivesCorrectTeamForGivenPosition()
        {

            FootballTeam teamOne = new FootballTeam("Steaua");
            FootballTeam teamTwo = new FootballTeam("Dinamo");
            FootballTeam teamThree = new FootballTeam("Nu mai stiu altele");
            FootballTeam teamFour = new FootballTeam("CFR Cluj");
            FootballTeam teamFive = new FootballTeam("Viitorul");

            teamOne.IncreasePoints(20);
            teamTwo.IncreasePoints(10);
            teamThree.IncreasePoints(50);
            teamFour.IncreasePoints(40);
            teamFive.IncreasePoints(30);

            List<FootballTeam> teams = new List<FootballTeam>();

            Ranking ranking = new Ranking();
            ranking.AddTeam(teamOne);
            ranking.AddTeam(teamTwo);
            ranking.AddTeam(teamThree);
            ranking.AddTeam(teamFour);
            ranking.AddTeam(teamFive);

            Assert.Equal(teamFive, ranking.GetTeamAtGivenPosition(2));
        }


        [Fact]
        public void ReturnsPositionOfGivenTeam()
        {

            FootballTeam teamOne = new FootballTeam("Steaua");
            FootballTeam teamTwo = new FootballTeam("Dinamo");
            FootballTeam teamThree = new FootballTeam("Nu mai stiu altele");
            FootballTeam teamFour = new FootballTeam("CFR Cluj");
            FootballTeam teamFive = new FootballTeam("Viitorul");

            teamOne.IncreasePoints(20);
            teamTwo.IncreasePoints(10);
            teamThree.IncreasePoints(50);
            teamFour.IncreasePoints(40);
            teamFive.IncreasePoints(30);

            List<FootballTeam> teams = new List<FootballTeam>();

            Ranking ranking = new Ranking();
            ranking.AddTeam(teamOne);
            ranking.AddTeam(teamTwo);
            ranking.AddTeam(teamThree);
            ranking.AddTeam(teamFour);
            ranking.AddTeam(teamFive);

            Assert.Equal(2, ranking.GetRanking(teamFive));
        }

        [Fact]
        public void ReturnsCorrectPostionAfterUpdate()
        {

            FootballTeam teamOne = new FootballTeam("Steaua");
            FootballTeam teamTwo = new FootballTeam("Dinamo");
            FootballTeam teamThree = new FootballTeam("Nu mai stiu altele");
            FootballTeam teamFour = new FootballTeam("CFR Cluj");
            FootballTeam teamFive = new FootballTeam("Viitorul");

            teamOne.IncreasePoints(10);
            teamTwo.IncreasePoints(10);
            teamThree.IncreasePoints(50);
            teamFour.IncreasePoints(40);
            teamFive.IncreasePoints(30);

            MatchResult matchResult = new MatchResult(5, 1);
            FootballMatch footballMatch = new FootballMatch(teamOne, teamTwo, matchResult);

            List<FootballTeam> teams = new List<FootballTeam>();

            Ranking ranking = new Ranking();
            ranking.AddTeam(teamOne);
            ranking.AddTeam(teamTwo);
            ranking.AddTeam(teamThree);
            ranking.AddTeam(teamFour);
            ranking.AddTeam(teamFive);

            ranking.UpdateRanking(footballMatch);

            Assert.Equal(4, ranking.GetRanking(teamOne));
        }

        [Fact]
        public void CanNotReturnPositionOFTeamNotInRanking()
        {

            FootballTeam teamOne = new FootballTeam("Steaua");
            FootballTeam teamTwo = new FootballTeam("Dinamo");
            FootballTeam teamThree = new FootballTeam("CFR");
            List<FootballTeam> teams = new List<FootballTeam>();
            teams.Add(teamOne);
            teams.Add(teamTwo);

            Ranking ranking = new Ranking();

            Assert.Equal(-1, ranking.GetRanking(teamThree));
        }




    }
}
