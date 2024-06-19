using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Models;

using System;
using System.ComponentModel.DataAnnotations;

[Index(nameof(Title), IsUnique = true)]
public class Post
{
    [Key] public int Id { get; init; }

    [Required] public required int UserId { get; init; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public required string Title { get; set; }

    [Required]
    [Column(TypeName = "varchar(max)")]
    public required string Content { get; set; }

    [Required] public DateTime CreatedAt { get; init; } = DateTime.Now;

    [JsonIgnore]
    public User? User { get; set; }

    [JsonIgnore]
    public ICollection<Comment>? Comments { get; set; }
}