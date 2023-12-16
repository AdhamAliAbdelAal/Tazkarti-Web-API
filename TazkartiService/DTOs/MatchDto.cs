using System.Text.Json.Serialization;

namespace TazkartiService.DTOs;

public class MatchDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("stadiumId")]
    public int StadiumId { get; set; }
    
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
    
    [JsonPropertyName("homeTeamId")]
    public int HomeTeamId { get; set; }
    
    [JsonPropertyName("awayTeamId")]
    public int AwayTeamId { get; set; }
    
    [JsonPropertyName("referee")]
    public string Referee { get; set; }
    
    [JsonPropertyName("linesmen1")]
    public string Linesmen1 { get; set; }
    
    [JsonPropertyName("linesmen2")]
    public string Linesmen2 { get; set; }
    
    [JsonPropertyName("seats")]
    public ICollection<SeatDto> Seats { get; set; }
}