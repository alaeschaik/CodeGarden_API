using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CodeGardenApi.Models;

public class Contribution
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int DiscussionId { get; set; }
    
    [Required]
    public int UserId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(max)")]
    public required string Content { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    public ICollection<Contribution>? Contributions { get; set; }
    
    [JsonIgnore]
    public User? User { get; set; }
    
    [JsonIgnore]
    public Discussion? Discussion { get; set; }
}