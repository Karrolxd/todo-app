using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.DTOs;
using ToDoApi.Models;
using Task = ToDoApi.Models.Task;

namespace ToDoApi.Services;

public class TaskService : ITaskService
{
    private readonly ToDoApiDbContext _context;
    public TaskService(ToDoApiDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Task>> GetTasksAsync(int userId)
    {
        return await _context.Tasks.Where(t => t.UserId == userId).ToListAsync();
    }

    public async Task<Task?> GetTaskByIdAsync(int taskId, int userId)
    {
        return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId && t.UserId == userId);
    }

    public async Task<Task> CreateTaskAsync(CreateTaskDto createTaskDto, int userId)
    {
        if (createTaskDto.DueDate.HasValue && createTaskDto.DueDate.Value < DateTime.UtcNow)
        {
            throw new Exception("Due date cannot be in the past.");
        }
        
        var task = new Task()
        {
            Title = createTaskDto.Title,
            Description = createTaskDto.Description,
            DueDate = createTaskDto.DueDate,
            Priority = Enum.Parse<TaskPriority>(createTaskDto.Priority, true),
            UserId = userId,
            CreatedDate = DateTime.UtcNow
        };
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        
        return task;
    }

    public async Task<bool> UpdateTaskAsync(int taskId, UpdateTaskDto updateTaskDto, int userId)
    {
        var task = await GetTaskByIdAsync(taskId, userId);
        if (task == null)
        {
            return false;
        }
        
        if (updateTaskDto.DueDate.HasValue && updateTaskDto.DueDate.Value < DateTime.UtcNow)
        {
            throw new Exception("Due date cannot be in the past.");
        }
        
        task.Title = updateTaskDto.Title;
        task.Description = updateTaskDto.Description;
        task.DueDate = updateTaskDto.DueDate;
        task.Priority = Enum.Parse<TaskPriority>(updateTaskDto.Priority, true);
        task.IsComplete = updateTaskDto.IsComplete;
        
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<bool> DeleteTaskAsync(int taskId, int userId)
    {
        var task = await GetTaskByIdAsync(taskId, userId);
        if (task == null)
        {
            return false;
        }
        
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        
        return true;
    }
}