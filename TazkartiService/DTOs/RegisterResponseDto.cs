using Newtonsoft.Json;

namespace TazkartiService.DTOs;

public class RegisterResponseDto
{
    [JsonProperty("token")]
    public string Token { get; set; }

    public RegisterResponseDto(string token)
    {
        Token = token;
    }
}