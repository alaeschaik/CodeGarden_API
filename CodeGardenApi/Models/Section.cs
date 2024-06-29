using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Models;

using System.ComponentModel.DataAnnotations;

[Index(nameof(Title), IsUnique = true)]
public class Section
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required int ModuleId { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public required string Title { get; set; }

    [Required]
    public required decimal XpPoints { get; set; }
    
    [JsonIgnore]
    public Module? Module { get; set; }
    [JsonIgnore]
    public ICollection<Challenge>? Challenges { get; set; }
}
