namespace TazkartiBusinessLayer.Exceptions;

public class StadiumNotFoundException: Exception
{
    public StadiumNotFoundException(int stadiumId) : base($"Stadium with id {stadiumId} not found")
    {
        
    }
}