using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CodeGardenApi.Models;

public class Question
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(max)")]
    public required string Content { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(max)")]
    public required string CorrectAnswer { get; set; }
    
    [Required]
    public int ChallengeId { get; set; }
    
    [Required]
    public QuestionType Type { get; set; }
    
    [JsonIgnore]
    public ICollection<Choice>? Choices { get; set; }
    
    [JsonIgnore]
    public Challenge? Challenge { get; set; }
}