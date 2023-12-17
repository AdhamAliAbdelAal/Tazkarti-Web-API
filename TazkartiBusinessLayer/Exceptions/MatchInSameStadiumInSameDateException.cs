namespace TazkartiBusinessLayer.Exceptions;

public class MatchInSameStadiumInSameDateException: Exception
{
    public MatchInSameStadiumInSameDateException() : base("match in same stadium in same date already exists")
    {
    }
}