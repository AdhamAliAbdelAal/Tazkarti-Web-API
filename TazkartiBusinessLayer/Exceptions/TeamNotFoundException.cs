namespace TazkartiBusinessLayer.Exceptions;

public class TeamNotFoundException: Exception
{
    public TeamNotFoundException(int id) : base($"Team with id {id} not found")
    {
    }
}