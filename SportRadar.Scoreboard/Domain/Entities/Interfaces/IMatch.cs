using SportRadar.Scoreboard.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportRadar.Scoreboard.Domain.Entities;

public interface IMatch
{
    Team HomeTeam { get; }
    Team AwayTeam { get; }
    DateTime StartDate { get; }
    MatchStatus Status { get; }
    uint HomeTeamScore { get; }
    uint AwayTeamScore { get; }
    uint TotalScore { get; }

    void StartMatch(DateTime? dateTime = null);
    void UpdateScore(uint homeScore, uint awayScore);
    void EndMatch();
    string GetMatchName();
    string GetMatchShortName();
    public string GetMatchResultSummary();
    public string GetMatchResultSummaryWithShortName();
}
