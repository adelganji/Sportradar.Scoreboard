using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportRadar.Scoreboard.Domain.Entities;

public class Team
{
    public string TeamName { get; private set; }

    /// <summary>
    /// Initial a FootbalTeam and give it a name
    /// </summary>
    /// <param name="teamName">name of the team, like : 'Germany'</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public Team(string teamName)
    {
        if (string.IsNullOrWhiteSpace(teamName))
            throw new ArgumentNullException(nameof(teamName), "The team name cannot be empty or null.");
        if (teamName.Trim().Length < 2)
            throw new ArgumentException("The team name must have more than 2 characters.", nameof(teamName));

        TeamName = teamName;
    }
}
