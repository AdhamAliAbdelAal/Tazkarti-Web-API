using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TazkartiDataAccessLayer.Models;

public class StadiumDbModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    
    [Required]
    public int Capacity { get; set; }
    
    [Required]
    public int VIPWidth { get; set; }
    
    [Required]
    public int VIPLength { get; set; }
}