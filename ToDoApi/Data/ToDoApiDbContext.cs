using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Data;

public class ToDoApiDbContext : DbContext
{
    public ToDoApiDbContext(DbContextOptions<ToDoApiDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}