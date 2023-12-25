using System.Text.Json.Serialization;

namespace TazkartiService.DTOs;

public class AddStadiumDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("capacity")]
    public int Capacity { get; set; }
    
    [JsonPropertyName("vipWidth")]
    public int VIPWidth { get; set; }

    [JsonPropertyName("vipLength")] 
    public int VIPLength { get; set; }
}