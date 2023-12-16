﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TazkartiDataAccessLayer.Models;

public class MatchDbModel
{
    [Key]
    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public int Id { get; set; }
    
    [Required]
    public StadiumDbModel Stadium { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public TeamDbModel HomeTeam { get; set; }
    
    [Required]
    public TeamDbModel AwayTeam { get; set; }
    
    [Required]
    public string Referee { get; set; }
    
    [Required]
    public string Linesmen1 { get; set; }
    
    [Required]
    public string Linesmen2 { get; set; }
    
}