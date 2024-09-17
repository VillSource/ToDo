using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskBoardsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetTaskBoards()
    {
        return Ok("NOT IMPLEMENT!!!");
    }

    [HttpGet("{id}")]
     public IActionResult GetTaskBoard(int id)
    {
        return Ok($"GET BOARD ID {id} IS NOT IMPLEMENT!!!");
    }
}
