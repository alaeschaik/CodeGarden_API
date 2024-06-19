using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Models;

using System.ComponentModel.DataAnnotations;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    public int Id { get; init; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public required string Username { get; init; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public required string Email { get; init; }

    [Required]
    [Column(TypeName = "varchar(max)")]
    public required string Password { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public required string Firstname { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public required string Lastname { get; set; }

    [Required] [Precision(20, 0)] public decimal XpPoints { get; set; } = 0;
    
    [Required]
    public required DateTime CreatedAt { get; init; } = DateTime.Now;

    [JsonIgnore]
    public ICollection<Post>? Posts { get; set; }
    [JsonIgnore]
    public ICollection<Comment>? Comments { get; set; }
}
