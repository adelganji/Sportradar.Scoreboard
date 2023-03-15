using SportRadar.Scoreboard.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportRadar.Scoreboard.Domain.Entities;

public class Match
{
    public Team HomeTeam { get; private set; }
    public Team AwayTeam { get; private set; }
    public MatchStatus Status { get; private set; }

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

}
