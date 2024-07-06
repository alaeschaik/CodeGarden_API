using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Models;


[Index(nameof(Title), IsUnique = true)]
public class Discussion
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(500)")]
    public required string Title { get; set; }

    [Required]
    [Column(TypeName = "varchar(max)")]
    public required string Content { get; set; }

    [Required]
    public int UserId { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }

    public ICollection<Contribution>? Contributions { get; set; }

    [JsonIgnore]
    public User? User { get; set; }
}