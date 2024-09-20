using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models;

public class Task
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string? Title { get; set; }
    
    [MaxLength(500)]
    public string? Description { get; set; }
    
    public DateTime? DueDate { get; set; }
    
    [Required]
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;
    
    public bool IsComplete { get; set; }
    
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    
    
    public int UserId { get; set; }
    public User? User { get; set; }
}

public enum TaskPriority
{
    Low,
    Medium,
    High
}