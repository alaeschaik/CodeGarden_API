using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CodeGardenApi.Models;

public class UserModule
{
    [Key]
    public int Id { get; init; }

    [Required]
    public int? UserId { get; set; }

    [Required]
    public int? ModuleId { get; set; }

    [Required]
    public ModuleState? State { get; set; } = ModuleState.Start;
    
    [JsonIgnore]
    public User? User { get; set; }
    
    [JsonIgnore]
    public Module? Module { get; set; }
}
