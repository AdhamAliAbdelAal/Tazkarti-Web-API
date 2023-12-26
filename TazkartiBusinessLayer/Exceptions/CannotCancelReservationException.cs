namespace TazkartiBusinessLayer.Exceptions;

public class CannotCancelReservationException: Exception
{
    public CannotCancelReservationException(): base("Cannot cancel reservation if the match is in less than 3 days")
    {
        
    }
}