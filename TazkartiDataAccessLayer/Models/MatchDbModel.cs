using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TazkartiDataAccessLayer.Models;

public class MatchDbModel
{
    [Key]
    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public int Id { get; set; }
    
    [Required]
    public int StadiumId { get; set; }
    
    public StadiumDbModel Stadium { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public TeamDbModel HomeTeam { get; set; }
    
    public int HomeTeamId { get; set; }
    
    [Required]
    public TeamDbModel AwayTeam { get; set; }
    
    public int AwayTeamId { get; set; }
    
    [Required]
    public string Referee { get; set; }
    
    [Required]
    public string Linesmen1 { get; set; }
    
    [Required]
    public string Linesmen2 { get; set; }
    
    public List<SeatDbModel> Seats { get; set; }
}