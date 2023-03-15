using SportRadar.Scoreboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SportRadar.Scoreboard;

public class Scoreboard
{
    private List<Match> _matchList;
    public string Name { get; private set; }
    public List<Match> MatchList => _matchList??= new List<Match>();

    /// <summary>
    /// Creates a new scoreboard.
    /// </summary>
    /// <param name="name"> Name of this scoreboard, like "WorldCup2022" </param>
    /// <exception cref="ArgumentNullException"></exception>
    public Scoreboard(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name),"You must set a name for this scoreboard");
        Name = name;
        _matchList = new List<Match>();
    }
    /// <summary>
    /// Add one Match to Scoreboard
    /// </summary>
    /// <param name="newMatch">a new match</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public bool AddMatch(Match newMatch)
    {
        if (newMatch == null)
            throw new ArgumentNullException(nameof(newMatch),"newMatch cannot be null");
        _matchList.Add(newMatch);
        return true;
    }

    /// <summary>
    /// Add list of Matchs to Scoreboard
    /// </summary>
    /// <param name="newMatchs"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public bool AddMatch(List<Match> newMatchs)
    {
        if ((!newMatchs.Any()) || newMatchs.Any(o => o == null))
            throw new ArgumentException("Invalid entry.",nameof(newMatchs));

        _matchList.AddRange(newMatchs);
        return true;
    }



}
