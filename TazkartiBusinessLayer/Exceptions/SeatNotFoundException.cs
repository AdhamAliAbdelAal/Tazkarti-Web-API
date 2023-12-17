namespace TazkartiBusinessLayer.Exceptions;

public class SeatNotFoundException: Exception
{
    public SeatNotFoundException(int capacity) : base($"Seat number must be between 1 and {capacity}")
    {
        
    }
}