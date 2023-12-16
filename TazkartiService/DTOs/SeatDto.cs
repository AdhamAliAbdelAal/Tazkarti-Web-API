using System.Text.Json.Serialization;

namespace TazkartiService.DTOs;

public class SeatDto
{
    [JsonPropertyName("number")]
    public int Number { get; set; }
    
    [JsonPropertyName("userId")]
    public int? UserId { get; set; }
    
    [JsonPropertyName("matchId")]
    public int MatchId { get; set; }
    
    [JsonPropertyName("reservedAt")]
    public DateTime ReservedAt { get; set; }
}