using ToDoApi.DTOs;
using Task = ToDoApi.Models.Task;

namespace ToDoApi.Services;

public interface ITaskService
{
    Task<IEnumerable<Task>> GetTasksAsync(int userId);
    Task<Task?> GetTaskByIdAsync(int taskId, int userId);
    Task<Task> CreateTaskAsync(CreateTaskDto createTaskDto, int userId);
    Task<bool> UpdateTaskAsync(int taskId, UpdateTaskDto updateTaskDto, int userId);
    Task<bool> DeleteTaskAsync(int taskId, int userId);
}