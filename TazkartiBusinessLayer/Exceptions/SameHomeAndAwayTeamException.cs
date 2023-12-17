namespace TazkartiBusinessLayer.Exceptions;

public class SameHomeAndAwayTeamException: Exception
{
    public SameHomeAndAwayTeamException() : base("home team and away team can't be the same")
    {
    }
}