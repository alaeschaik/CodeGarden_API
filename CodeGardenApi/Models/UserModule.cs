using System.ComponentModel.DataAnnotations;

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
}
