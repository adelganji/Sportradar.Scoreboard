using SportRadar.Scoreboard.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportRadar.Scoreboard.Domain.Entities;

public interface IMatch
{
    public interface IMatch
    {
        Team HomeTeam { get; }
        Team AwayTeam { get; }
        MatchStatus Status { get; }
        DateTime StartDate { get; }
        uint HomeTeamScore { get; }
        uint AwayTeamScore { get; }

        void StartMatch(DateTime? dateTime = null);
    }
}
