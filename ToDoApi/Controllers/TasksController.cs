using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.DTOs;
using ToDoApi.Services;

namespace ToDoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;
    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var userId = int.Parse(User.FindFirst("userId")?.Value);
        var tasks = await _taskService.GetTasksAsync(userId);
        
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var userId = int.Parse(User.FindFirst("userId")?.Value);
        var task = await _taskService.GetTaskByIdAsync(id, userId);
        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto createTaskDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var userId = int.Parse(User.FindFirst("userId")?.Value);
        var newTask = await _taskService.CreateTaskAsync(createTaskDto, userId);
        
        return CreatedAtAction(nameof(GetTaskById), new { id = newTask.Id }, newTask);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskDto updateTaskDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var userId = int.Parse(User.FindFirst("userId")?.Value);
        var isUpdated = await _taskService.UpdateTaskAsync(id, updateTaskDto, userId);
        
        if (!isUpdated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var userId = int.Parse(User.FindFirst("userId")?.Value);
        var isDeleted = await _taskService.DeleteTaskAsync(id, userId);
        
        if (!isDeleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}