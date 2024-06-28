using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Models;

public enum ModuleState
{
    Start,
    Continue
}

[Index(nameof(UserId), IsUnique = true)]
[Index(nameof(ModuleId), IsUnique = true)]
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
