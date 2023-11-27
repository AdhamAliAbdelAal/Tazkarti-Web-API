using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TazkartiDataAccessLayer.DataTypes;

namespace TazkartiDataAccessLayer.Models;

public class UserDbModel
{
    [Key]
    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public string Id { get; set; } = null!;
    
    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = null!;
    
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public DateTime BirthDate { get; set; }
    
    public GenderType Gender { get; set; }
    
    public string City { get; set; } = null!;
    
    public string Address { get; set; } = null!;
    
    public string EmailAddress { get; set; } = null!;
    
    public Role Role { get; set; }
    
}