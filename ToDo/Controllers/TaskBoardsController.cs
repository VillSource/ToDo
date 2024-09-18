using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskBoardsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTaskBoards()
    {
        return Ok("NOT IMPLEMENT!!!");
    }

    [HttpGet("{id}")]
     public async Task<IActionResult> GetTaskBoard(int id)
    {
        return Ok($"GET BOARD ID {id} IS NOT IMPLEMENT!!!");
    }
}
