using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;
using Task = ToDoApi.Models.Task;

namespace ToDoApi.Data;

public class ToDoApiDbContext : DbContext
{
    public ToDoApiDbContext(DbContextOptions<ToDoApiDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.Tasks)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}