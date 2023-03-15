using SportRadar.Scoreboard.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportRadar.Scoreboard.Domain.Entities;

public class Match : IMatch
{
    public Team HomeTeam { get; private set; }
    public Team AwayTeam { get; private set; }
    public MatchStatus Status { get; private set; }
    public DateTime StartDate { get; private set; }
    public uint HomeTeamScore { get; private set; }
    public uint AwayTeamScore { get; private set; }


    /// <summary>
    /// Create a footbal match with 2 footbal teams.
    /// </summary>
    /// <param name="homeTeam">The one who is hosting the game.</param>
    /// <param name="awayTeam">The team that is visiting and playing at their opponent's home field.</param>
    public Match(Team homeTeam, Team awayTeam)
    {
        if (homeTeam == null || awayTeam == null)
            throw new InvalidOperationException("'HomeTeam' and 'AwayTeam' must be initialized correctly.");
        if (homeTeam.TeamName == awayTeam.TeamName)
            throw new ArgumentException("Home team name and away team name cannot be the same.", nameof(awayTeam));

        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        Status = MatchStatus.NOT_STARTED;
    }

    /// <summary>
    /// The match is started at the given date/time or just started.
    /// </summary>
    /// <param name="dateTime">If you want to start a match at a particular time you can set this parameter, 
    /// otherwise, it will be started right now!</param>
    public void StartMatch(DateTime? dateTime = null)
    {
        teamsAreValid();
        StartDate = dateTime ?? DateTime.Now;
        // if (StartDate > DateTime.Now)
        //     throw new InvalidDataException();
        HomeTeamScore = 0;
        AwayTeamScore = 0;
        Status = MatchStatus.STARTED_AND_INPROGRESS; // Of course the match will start at the time, but I imagine that the game has started here.
    }


    #region private methods

    /// <summary>
    /// It checks HomeTeam and AwayTeam to be correct, otherwise, throws an exception.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    private void teamsAreValid()
    {
        if (HomeTeam == null || AwayTeam == null)
            throw new InvalidOperationException("'HomeTeam' and 'AwayTeam' must be initialized correctly.");
    }
    #endregion
}
