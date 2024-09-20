using System.ComponentModel.DataAnnotations;

namespace ToDoApi.DTOs;

public class UpdateTaskDto
{
    [Required]
    [MaxLength(100)]
    public string? Title { get; set; }
    
    [MaxLength(500)]
    public string? Description { get; set; }
    
    public DateTime? DueDate { get; set; }
    
    [Required]
    public string Priority { get; set; } = "Medium";
    
    public bool IsComplete { get; set; }
}