using Microsoft.EntityFrameworkCore;

namespace ToDoApi.Data;

public class ToDoApiDbContext : DbContext
{
    public ToDoApiDbContext(DbContextOptions<ToDoApiDbContext> options) : base(options)
    {
    }
}