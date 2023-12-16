using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TazkartiDataAccessLayer.Models;

public class SeatDbModel
{
    [Required]
    public int Number { get; set; }
    
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public int MatchId { get; set; }
    
    public DateTime ReservedAt { get; set; } = DateTime.Now;
    
}