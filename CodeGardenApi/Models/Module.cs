using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Models;

using System.ComponentModel.DataAnnotations;

[Index(nameof(Title), IsUnique = true)]
public class Module
{
    [Key]
    public int Id { get; init; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public required string Title { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public required string Description { get; set; }

    [Required]
    [Column(TypeName = "varchar(1000)")]
    public required string Introduction { get; set; }
    
    [Required]
    [Precision(20, 0)]
    public required decimal TotalXpPoints { get; set; }

    [Required]
    [Column(TypeName = "varchar(max)")]
    public required string Content { get; set; }
    
    // [JsonIgnore]
    [Column(TypeName = "varchar(max)")]
    public ICollection<Section>? Sections { get; set; }
}
