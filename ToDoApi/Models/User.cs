using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    
    [Required]
    public string? PasswordHash { get; set; }

    public List<Task> Tasks { get; set; } = new List<Task>();
}