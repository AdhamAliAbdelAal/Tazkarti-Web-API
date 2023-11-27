using Newtonsoft.Json;

namespace TazkartiService.DTOs;

public class LoginResponseDto
{
    [JsonProperty("token")]
    public string Token { get; set; }

    public LoginResponseDto(string token)
    {
        Token = token;
    }
}