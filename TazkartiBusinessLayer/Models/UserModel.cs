using TazkartiDataAccessLayer.DataTypes;
using TazkartiDataAccessLayer.Models;

namespace TazkartiBusinessLayer.Models;

public class UserModel
{
    public string Username { get; set; } = null!;
    
    public string Password { get; set; } = null!;
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public DateTime? BirthDate { get; set; }
    
    public GenderType? Gender { get; set; }
    
    public string? City { get; set; }
    
    public string? Address { get; set; }
    
    public string? EmailAddress { get; set; }
    public Role Role { get; set; }
    
    public UserStatus Status { get; set; }
}