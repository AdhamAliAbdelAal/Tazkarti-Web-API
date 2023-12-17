using System.Text.Json.Serialization;

namespace TazkartiService.DTOs;

public class TeamDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
}