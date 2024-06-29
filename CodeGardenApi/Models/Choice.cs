using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeGardenApi.Models;

public class Choice
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(max)")]
    public required string Content { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(100)")]
    public bool IsCorrect { get; set; }
}
