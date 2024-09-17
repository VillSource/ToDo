using Microsoft.AspNetCore.Mvc;
using ToDo.Services;

namespace ToDo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskItemsController(
        TaskItemService _taskItemService
    ) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTaskItemsAsync()
    {
        var items = await _taskItemService.GetItemsAsync();

        if (items.Count == 0)
            return NotFound();

        return Ok(items);
    }

    [HttpGet("{id}")]
     public async Task<IActionResult> GetTaskItemAsync(int id)
    {
        try
        {
            var items = await _taskItemService.GetItemAsync(id);
            return Ok(items);
        }
        catch
        {
            return NotFound();
        }

    }

}
