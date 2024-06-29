using System.Collections.Specialized;
using CodeGardenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.Data;

public class CodeGardenContext(DbContextOptions<CodeGardenContext> options) : DbContext(options)
{

    public DbSet<User> Users { get; init; }
    public DbSet<Post> Posts { get; init; }
    public DbSet<Comment> Comments { get; init; }
    public DbSet<Module> Modules { get; init; }
    public DbSet<Section> Sections { get; init; }
    public DbSet<Challenge> Challenges { get; init; }
    public DbSet<UserModule> UserModules { get; init; }
    public DbSet<Choice> Choices { get; init; }
    public DbSet<OpenEndedQuestion> OpenEndedQuestions { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(e => e.Id);
        });
        
        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Posts");
            entity.HasKey(e => e.Id);
            entity.HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

        });
        
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comments");
            entity.HasKey(e => e.Id);
            entity.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);
            
            entity.HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        });
        
        modelBuilder.Entity<Module>(entity =>
        {
            entity.ToTable("Modules");
            entity.HasKey(e => e.Id);
        });
        
        modelBuilder.Entity<Section>(entity =>
        {
            entity.ToTable("Sections");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.XpPoints)
                .HasColumnType("decimal(20, 0)");
            entity.HasOne(s => s.Module)
                .WithMany(m => m.Sections)
                .HasForeignKey(s => s.ModuleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasMany<Challenge>()
                .WithOne(ch => ch.Section)
                .HasForeignKey(c => c.SectionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        });
        
        modelBuilder.Entity<Challenge>(entity =>
        {
            entity.ToTable("Challenges");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ChallengeType)
                .HasConversion<string>();
            entity.HasOne(ch => ch.Section)
                .WithMany(s => s.Challenges)
                .HasForeignKey(ch => ch.SectionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        });
        base.OnModelCreating(modelBuilder);
    }
}