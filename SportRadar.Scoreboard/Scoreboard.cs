using SportRadar.Scoreboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportRadar.Scoreboard;

public class Scoreboard
{
    public string Name { get; private set; }

    /// <summary>
    /// Creates a new football scoreboard.
    /// </summary>
    /// <param name="name"> Name of this scoreboard, like "WorldCup2022" </param>
    /// <exception cref="ArgumentNullException"></exception>
    public Scoreboard(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("You must set a name for this football scoreboard");
        Name = name;
    }

}
