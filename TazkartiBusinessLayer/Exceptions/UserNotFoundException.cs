namespace TazkartiBusinessLayer.Exceptions;

public class UserNotFoundException: Exception
{
    public UserNotFoundException(string username) : base($"User with username {username} not found")
    {
    }
}