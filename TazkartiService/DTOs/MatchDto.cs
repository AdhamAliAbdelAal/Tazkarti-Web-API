using System.Text.Json.Serialization;

namespace TazkartiService.DTOs;

public class MatchDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("stadium")]
    public StadiumDto Stadium { get; set; }
    
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
    
    [JsonPropertyName("homeTeam")]
    public TeamDto HomeTeam { get; set; }
    
    [JsonPropertyName("awayTeam")]
    public TeamDto AwayTeam { get; set; }
    
    [JsonPropertyName("referee")]
    public string Referee { get; set; }
    
    [JsonPropertyName("linesmen1")]
    public string Linesmen1 { get; set; }
    
    [JsonPropertyName("linesmen2")]
    public string Linesmen2 { get; set; }
    
    [JsonPropertyName("seats")]
    public IEnumerable<SeatDto> Seats { get; set; }
}