namespace TazkartiBusinessLayer.Exceptions;

public class ResvervedSeatOrUserException: Exception
{
    public ResvervedSeatOrUserException() : base("Seat is already reserved or user is already reserved a seat")
    {
    }
}