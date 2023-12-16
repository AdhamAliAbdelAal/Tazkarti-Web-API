using System.ComponentModel.DataAnnotations;

namespace TazkartiBusinessLayer.Models;

public class MatchModel
{
    public int Id { get; set; }
    
    [Required]
    public int StadiumId { get; set; }
    
    public DateTime Date { get; set; }
    
    public int HomeTeamId { get; set; }
    
    public int AwayTeamId { get; set; }
    
    public string Referee { get; set; }
    
    public string Linesmen1 { get; set; }
    
    public string Linesmen2 { get; set; }
    
    public ICollection<SeatModel> Seats { get; set; }
}