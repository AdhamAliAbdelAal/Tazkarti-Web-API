namespace TazkartiBusinessLayer.Exceptions;

public class MatchNotFoundException: Exception
{
    public MatchNotFoundException(int id) : base($"Match with id {id} not found")
    {
    }
}