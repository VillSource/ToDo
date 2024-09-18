using Microsoft.AspNetCore.Mvc;
using ToDo.Services;

namespace ToDo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskItemsController(
        ITaskItemService _taskItemService
    ) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTaskItemsAsync()
    {
        var items = await _taskItemService.GetItemsAsync();

        if (items.Status == Utility.ResultStatus.NotFound)
            return NotFound();

        if (items.Status == Utility.ResultStatus.Success)
            return Ok(items.Value);

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskItemAsync(int id)
    {
        var items = await _taskItemService.GetItemAsync(id);

        if (items.Status == Utility.ResultStatus.NotFound)
            return NotFound();

        if (items.Status == Utility.ResultStatus.Success)
            return Ok(items.Value);

        return BadRequest();
    }

}
