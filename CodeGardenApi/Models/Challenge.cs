using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CodeGardenApi.Models;

using System.ComponentModel.DataAnnotations;

public class Challenge
{
    [Key]
    public int Id { get; init; }

    [Required]
    public ChallengeType ChallengeType { get; set; }  // e.g., "multiple_choice", "question", "code_snippet", "learning_content"

    [Required]
    public required int SectionId { get; set; }

    [Required]
    [Column(TypeName = "varchar(max)")]
    public required string Content { get; set; }
    
    [JsonIgnore]
    public Section? Section { get; set; }
    
    [JsonIgnore]
    public ICollection<Question>? Questions { get; set; }
}
