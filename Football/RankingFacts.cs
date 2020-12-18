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
        public void NullTeamCanNotBeAddedToRanking()
        {
            
            FootballTeam teamOne = new FootballTeam("Steaua");
            FootballTeam teamTwo = new FootballTeam("");
            
            List<FootballTeam> teams = new List<FootballTeam>
            {
                teamOne
            };

            Ranking ranking = new Ranking(teams);

            Assert.Equal("Not added!", ranking.AddTeamToRanking(teamTwo));         
        }

        [Fact]
        public void TeamWithValidNameCanBeAddedToRanking()
        {

            FootballTeam teamOne = new FootballTeam("Steaua");
            FootballTeam teamTwo = new FootballTeam("Dinamo");

            List<FootballTeam> teams = new List<FootballTeam>
            {
                teamOne
            };

            Ranking ranking = new Ranking(teams);

            Assert.Equal("Added with success!", ranking.AddTeamToRanking(teamTwo));
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

            Ranking ranking = new Ranking(teams);
            ranking.AddTeamToRanking(teamOne);
            ranking.AddTeamToRanking(teamTwo);
            ranking.AddTeamToRanking(teamThree);
            ranking.AddTeamToRanking(teamFour);
            ranking.AddTeamToRanking(teamFive);

            Assert.Equal(teamFive.ToString(), ranking.GetTeamAtGivenPosition(2));
        }

        [Fact]
        public void DoesNotReturnPositionIfThereIsNoTeamAtTheGivenPosition()
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

            Ranking ranking = new Ranking(teams);
            ranking.AddTeamToRanking(teamOne);
            ranking.AddTeamToRanking(teamTwo);
            ranking.AddTeamToRanking(teamThree);
            ranking.AddTeamToRanking(teamFour);
            ranking.AddTeamToRanking(teamFive);

            Assert.Equal("No team for the given position!", ranking.GetTeamAtGivenPosition(5));
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

            Ranking ranking = new Ranking(teams);
            ranking.AddTeamToRanking(teamOne);
            ranking.AddTeamToRanking(teamTwo);
            ranking.AddTeamToRanking(teamThree);
            ranking.AddTeamToRanking(teamFour);
            ranking.AddTeamToRanking(teamFive);

            Assert.Equal("2", ranking.GetRankingOfGivenTeam(teamFive));
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

            Ranking ranking = new Ranking(teams);
            ranking.AddTeamToRanking(teamOne);
            ranking.AddTeamToRanking(teamTwo);
            ranking.AddTeamToRanking(teamThree);
            ranking.AddTeamToRanking(teamFour);
            ranking.AddTeamToRanking(teamFive);

            ranking.UpdateRanking(footballMatch);

            Assert.Equal("4", ranking.GetRankingOfGivenTeam(teamOne));
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

            Ranking ranking = new Ranking(teams);

            Assert.Equal("Your favorite team is not that cool!", ranking.GetRankingOfGivenTeam(teamThree));
        }




    }
}
