using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CodeGardenApi.Models;

public class OpenEndedQuestion
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(max)")]
    public required string Content { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(max)")]
    public required string CorrectAnswer { get; set; }
    
    [JsonIgnore]
    public ICollection<Choice>? Choices { get; set; }
}