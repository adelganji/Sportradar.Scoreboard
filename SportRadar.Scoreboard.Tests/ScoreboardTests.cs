using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportRadar.Scoreboard.Domain.Entities;
using SportRadar.Scoreboard.Domain.Enums;

namespace SportRadar.Scoreboard.Tests;

public class ScoreboardTests
{
    public class TeamTests
    {
        [Theory]
        [InlineData("Mexico")]
        [InlineData("Canada")]
        [InlineData("Spain")]
        [InlineData("Brazil")]
        [InlineData("Germany")]
        [InlineData("France")]
        [InlineData("Uruguay")]
        [InlineData("Italy")]
        [InlineData("Argentina")]
        [InlineData("Australia")]
        public void CreateTeam(string teamName)
        {
            var team = new Team(teamName);
            Assert.Equal(team.TeamName, teamName);
        }
    }

    public class MatchTests
    {
        [Theory]
        [InlineData("Mexico", "Canada")]
        [InlineData("Spain", "Brazil")]
        [InlineData("Germany", "France ")]
        [InlineData("Uruguay", "Italy ")]
        [InlineData("Argentina", "Australia")]
        public void CreateAMatchBetweenTwoTeams(string homeTeam, string awayTeam, MatchStatus matchStatusExpectedValue = MatchStatus.NOT_STARTED)
        {
            if(homeTeam == awayTeam)
                throw new ArgumentException("Home team name and away team name cannot be the same.", nameof(awayTeam));
            var _homeTeam = new Team(homeTeam);
            var _awayTeam = new Team(awayTeam);

            var _newMatch = new Match(_homeTeam, _awayTeam);

            Assert.Equal(_newMatch.HomeTeam.TeamName, homeTeam);
            Assert.Equal(_newMatch.AwayTeam.TeamName, awayTeam);

            Assert.Equal(_newMatch.Status, matchStatusExpectedValue);
        }

    }

}
