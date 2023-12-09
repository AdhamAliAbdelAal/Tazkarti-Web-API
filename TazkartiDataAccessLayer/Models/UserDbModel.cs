using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TazkartiDataAccessLayer.DataTypes;

namespace TazkartiDataAccessLayer.Models;

public class UserDbModel
{
    [Key]
    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = null!;
    
    [Required]
    [MaxLength(50)]
    public string Password { get; set; } = null!;
    
    // is nullable
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public DateTime? BirthDate { get; set; } = DateTime.Now;
    
    public GenderType? Gender { get; set; }
    
    public string? City { get; set; }
    
    public string? Address { get; set; } 
    
    public string? EmailAddress { get; set; }
    
    public Role Role { get; set; }
    
    [DefaultValue(UserStatus.Pending)]
    public UserStatus Status { get; set; }
    
}