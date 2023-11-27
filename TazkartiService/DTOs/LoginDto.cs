using Newtonsoft.Json;

namespace TazkartiService.DTOs;

public class LoginDto
{
    [JsonProperty("username")]
    public string Username { get; set; }
    
    [JsonProperty("password")]
    public string Password { get; set; }
}