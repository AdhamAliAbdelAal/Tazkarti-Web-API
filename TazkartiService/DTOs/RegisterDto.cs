using Newtonsoft.Json;
using TazkartiDataAccessLayer.DataTypes;

namespace TazkartiService.DTOs;

public class RegisterDto
{
    [JsonProperty("username")]
    public string Username { get; set; }
    
    [JsonProperty("password")]
    public string Password { get; set; }
    
    [JsonProperty("role")]
    public Role Role { get; set; }
}