using System;
using System.Collections.Generic;
using System.Globalization;
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
            if (homeTeam == awayTeam)
                throw new ArgumentException("Home team name and away team name cannot be the same.", nameof(awayTeam));
            var _homeTeam = new Team(homeTeam);
            var _awayTeam = new Team(awayTeam);

            var _newMatch = new Match(_homeTeam, _awayTeam);

            Assert.Equal(_newMatch.HomeTeam.TeamName, homeTeam);
            Assert.Equal(_newMatch.AwayTeam.TeamName, awayTeam);

            Assert.Equal(_newMatch.Status, matchStatusExpectedValue);
        }

        [Theory]
        [InlineData("Mexico", "Canada", "03-14-2023 20:30:00")]
        [InlineData("Spain", "Brazil", "03-14-2023 20:31:00")]
        [InlineData("Germany", "France ", "03-14-2023 20:32:00")]
        [InlineData("Uruguay", "Italy ", "03-14-2023 20:33:00")]
        [InlineData("Argentina", "Australia", "03-14-2023 20:34:00")]
        public void StartAMatchBetweenTwoTeamsAtACertainTime(string homeTeam, string awayTeam, string matchStartDate,
            int matchStartYearExpectedValue = 2023,
            int matchStartMonthExpectedValue = 3,
            int matchStartDayExpectedValue = 14,
            MatchStatus matchStatusExpectedValue = MatchStatus.STARTED_AND_INPROGRESS
            )
        {
            var _homeTeam = new Team(homeTeam);
            var _awayTeam = new Team(awayTeam);

            var _newMatch = new Match(_homeTeam, _awayTeam);

            DateTime dt = DateTime.ParseExact(matchStartDate, "MM-dd-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            _newMatch.StartMatch(dt);

            Assert.Equal(_newMatch.StartDate.Year, matchStartYearExpectedValue);
            Assert.Equal(_newMatch.StartDate.Month, matchStartMonthExpectedValue);
            Assert.Equal(_newMatch.StartDate.Day, matchStartDayExpectedValue);
            Assert.Equal(_newMatch.Status, matchStatusExpectedValue);
        }
        [Theory]
        [InlineData("Mexico", 0, "Canada", 5)]
        [InlineData("Spain", 10, "Brazil", 2)]
        [InlineData("Germany", 2, "France ", 2)]
        [InlineData("Uruguay", 6, "Italy ", 6)]
        [InlineData("Argentina", 3, "Australia", 1)]
        public void CreateAMatchAndStartTtAndUpdateMatchScore(string homeTeam, uint homeTeamScore, string awayTeam, uint awayTeamScore,
            MatchStatus matchStatusExpectedValue = MatchStatus.STARTED_AND_INPROGRESS)
        {
            var _homeTeam = new Team(homeTeam);
            var _awayTeam = new Team(awayTeam);

            var _newMatch = new Match(_homeTeam, _awayTeam);
            _newMatch.StartMatch();

            _newMatch.UpdateScore(homeTeamScore, awayTeamScore);

            Assert.Equal(_newMatch.HomeTeamScore, homeTeamScore);
            Assert.Equal(_newMatch.AwayTeamScore, awayTeamScore);
            Assert.Equal(_newMatch.TotalScore, homeTeamScore + awayTeamScore);
            Assert.Equal(_newMatch.Status, matchStatusExpectedValue);
        }


        [Theory]
        [InlineData("Mexico", 0, "Canada", 5)]
        [InlineData("Spain", 10, "Brazil", 2)]
        [InlineData("Germany", 2, "France ", 2)]
        [InlineData("Uruguay", 6, "Italy ", 6)]
        [InlineData("Argentina", 3, "Australia", 1)]
        public void CreateAMatchAndStartTtAndUpdateMatchScoreAndFinishTheMatch(string homeTeam, uint homeTeamScore, string awayTeam, uint awayTeamScore,
            MatchStatus matchStatusExpectedValue = MatchStatus.ENDED)
        {
            var _homeTeam = new Team(homeTeam);
            var _awayTeam = new Team(awayTeam);

            var _newMatch = new Match(_homeTeam, _awayTeam);
            _newMatch.StartMatch();

            _newMatch.UpdateScore(homeTeamScore, awayTeamScore);
            _newMatch.EndMatch();

            Assert.Equal(_newMatch.Status, matchStatusExpectedValue);
        }
    }

    public class MainScoreboardTests
    {
        [Fact]
        public void CreateANewScoreboard_Name_WorldCup()
        {
            var newBoardName = "WorldCup";
            var newScoreboard = new Scoreboard(newBoardName);

            Assert.Equal(newScoreboard.Name, newBoardName);
        }

        [Fact]
        public void CreateANewScoreboard_Name_WorldCup_AddSomeMatch()
        {
            var newBoardName = "WorldCup";
            var NewScoreboard = new Scoreboard(newBoardName);

            var newMatch_Mex_Can = new Match(new Team("Mexico"), new Team("Canada"));
            var newMatch_Spn_Bra = new Match(new Team("Spain"), new Team("Brazil"));
            var newMatch_Ger_Fra = new Match(new Team("Germany"), new Team("France"));
            var newMatch_Uru_Ita = new Match(new Team("Uruguay"), new Team("Italy"));
            var newMatch_Arg_Aus = new Match(new Team("Argentina"), new Team("Australia"));

            NewScoreboard.AddMatch(newMatch_Mex_Can);
            NewScoreboard.AddMatch(new List<Match> {
            newMatch_Spn_Bra,
            newMatch_Ger_Fra,
            newMatch_Uru_Ita,
            newMatch_Arg_Aus,
            });

            Assert.Equal(NewScoreboard.Name, newBoardName);
            Assert.Equal(5, NewScoreboard.MatchList.Count);
            Assert.Equal("Mexico - Canada", NewScoreboard.MatchList[0].GetMatchName());
            Assert.Equal("Spain - Brazil", NewScoreboard.MatchList[1].GetMatchName());
            Assert.Equal("Germany - France", NewScoreboard.MatchList[2].GetMatchName());
            Assert.Equal("Uruguay - Italy", NewScoreboard.MatchList[3].GetMatchName());
            Assert.Equal("Argentina - Australia", NewScoreboard.MatchList[4].GetMatchName());

            Assert.Equal("Mex - Can", NewScoreboard.MatchList[0].GetMatchShortName());
            Assert.Equal("Spa - Bra", NewScoreboard.MatchList[1].GetMatchShortName());
            Assert.Equal("Ger - Fra", NewScoreboard.MatchList[2].GetMatchShortName());
            Assert.Equal("Uru - Ita", NewScoreboard.MatchList[3].GetMatchShortName());
            Assert.Equal("Arg - Aus", NewScoreboard.MatchList[4].GetMatchShortName());
        }

    }
}
