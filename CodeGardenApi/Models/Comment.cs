using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CodeGardenApi.Models;

using System;
using System.ComponentModel.DataAnnotations;

public class Comment
{
    [Key]
    public int Id { get; init; }

    [Required]
    public required int PostId { get; init; }

    [Required]
    public required int UserId { get; init; }
    
    [Required]
    [Column(TypeName = "varchar(max)")]
    public required string Content { get; set; }

    public DateTime CreatedAt { get; init; } = DateTime.Now;
    
    [JsonIgnore]
    public Post? Post { get; set; }
    [JsonIgnore]
    public User? User { get; set; }
}
