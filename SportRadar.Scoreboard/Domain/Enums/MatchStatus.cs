namespace SportRadar.Scoreboard.Domain.Enums;

/// <summary>
/// the status of every match. Is it started? Or it is in progress? Or maybe it is finished?
/// </summary>
public enum MatchStatus
{
    NOT_STARTED = 0,
    STARTED_AND_INPROGRESS = 1,
    ENDED = 2,
}
