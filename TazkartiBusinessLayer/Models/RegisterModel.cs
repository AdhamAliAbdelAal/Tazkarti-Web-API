using TazkartiDataAccessLayer.DataTypes;

namespace TazkartiBusinessLayer.Models;

public class RegisterModel
{
    public string Username { get; set; } = null!;
    
    public string Password { get; set; } = null!;
    
    public Role Role { get; set; }
    
}