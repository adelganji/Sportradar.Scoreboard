﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportRadar.Scoreboard.Domain.Entities;

public class Team
{
    private const int MIN_TEAM_NAME_LENGTH = 2;
    private const int MAX_SHORT_NAME_LENGTH = 3;

    public string TeamName { get; private set; }

    /// <summary>
    /// Returns short name of the team
    /// </summary>
    /// <returns>'fra' for 'france'</returns>
    public string TeamShortName => TeamName.Substring(0, TeamName.Length >= MAX_SHORT_NAME_LENGTH ? MAX_SHORT_NAME_LENGTH : TeamName.Length);

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
        if (teamName.Trim().Length < MIN_TEAM_NAME_LENGTH)
            throw new ArgumentException("The team name must have more than 2 characters.", nameof(teamName));

        TeamName = teamName;
    }
}
