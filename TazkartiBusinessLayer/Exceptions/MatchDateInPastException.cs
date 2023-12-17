namespace TazkartiBusinessLayer.Exceptions;

public class MatchDateInPastException: Exception
{
    public MatchDateInPastException() : base("match date can't be in the past")
    {
    }
}