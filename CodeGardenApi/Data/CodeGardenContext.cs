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
    public DbSet<Question> Questions { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
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
            entity.HasMany(m => m.Sections)
                .WithOne(s => s.Module)
                .HasForeignKey(s => s.ModuleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Section>(entity =>
        {
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
            entity.Property(e => e.ChallengeType)
                .HasConversion<string>();

            entity.HasOne(ch => ch.Section)
                .WithMany(s => s.Challenges)
                .HasForeignKey(ch => ch.SectionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany<Question>()
                .WithOne(q => q.Challenge)
                .HasForeignKey(q => q.ChallengeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasOne(q => q.Challenge)
                .WithMany(ch => ch.Questions)
                .HasForeignKey(q => q.ChallengeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(q => q.Choices)
                .WithOne(c => c.Question)
                .HasForeignKey(c => c.QuestionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });
        base.OnModelCreating(modelBuilder);
    }
}