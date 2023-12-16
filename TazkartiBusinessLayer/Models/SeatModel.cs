namespace TazkartiBusinessLayer.Models;

public class SeatModel
{
    public int Number { get; set; }
    
    public int UserId { get; set; }
    
    public int MatchId { get; set; }
    
    public DateTime ReservedAt { get; set; }
}