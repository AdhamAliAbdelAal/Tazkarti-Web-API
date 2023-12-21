using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TazkartiDataAccessLayer.DataTypes;

namespace TazkartiService.DTOs;

public class UpdateUserDto
{
    [JsonPropertyName("password")]
    public string Password { get; set; }
    
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }
    
    [JsonPropertyName("birthDate")]
    public DateTime BirthDate { get; set; }
    
    [JsonPropertyName("address")]
    public string Address { get; set; }
    
    [JsonPropertyName("gender")]
    [EnumDataType(typeof(GenderType))]
    public GenderType Gender { set; get; }
    
    [JsonPropertyName("city")]
    public string City { get; set; }
}