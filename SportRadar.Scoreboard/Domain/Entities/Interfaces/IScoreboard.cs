
namespace SportRadar.Scoreboard.Domain.Entities.Interfaces;
public interface IScoreboard
{
    string Name { get; }
    List<Match> MatchList { get; }

    bool AddMatch(Match newMatch);
    bool AddMatch(List<Match> newMatchs);
    List<Match> GetOnlineMatches();
    List<Match> GetAllMatches();
}