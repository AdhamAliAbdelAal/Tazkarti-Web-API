using System.Text.Json.Serialization;
using TazkartiDataAccessLayer.DataTypes;

namespace TazkartiService.DTOs;

public class UserDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;
    
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }
    
    [JsonPropertyName("birthDate")]
    public DateTime? BirthDate { get; set; } = DateTime.Now;
    
    [JsonPropertyName("gender")]
    public GenderType Gender { get; set; }
    
    [JsonPropertyName("city")]
    public string City { get; set; }
    
    [JsonPropertyName("address")]
    public string Address { get; set; } 
    
    [JsonPropertyName("email")]
    public string EmailAddress { get; set; }
    
    [JsonPropertyName("role")]
    public Role Role { get; set; }
    
    [JsonPropertyName("status")]
    public UserStatus Status { get; set; }
}