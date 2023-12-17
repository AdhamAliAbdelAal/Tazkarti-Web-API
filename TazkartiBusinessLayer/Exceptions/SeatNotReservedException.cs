namespace TazkartiBusinessLayer.Exceptions;

public class SeatNotReservedException: Exception
{
    public SeatNotReservedException() : base("Seat is not reserved yet")
    {
        
    }
}