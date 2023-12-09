using TazkartiDataAccessLayer.DataTypes;

namespace TazkartiBusinessLayer.Models;

public class RegisterModel
{
    public string Username { get; set; } = null!;
    
    public string Password { get; set; } = null!;
    
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public DateTime BirthDate { get; set; } = DateTime.Now;
    
    public string Address { get; set; } = null!;
    
    public string EmailAddress { get; set; } = null!;

    public GenderType Gender { set; get; }
    
    public string City { get; set; } = null!;

    public Role Role { get; set; }
    
}