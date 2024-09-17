using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUserProfiles()
    {
        return Ok("NOT IMPLEMENT!!");
    }

    [HttpGet("{username}")]
    public IActionResult GetUserProfile(string username)
    {
        return Ok($"GET {username} PROFILE NOT IMPLEMENT!!");
    }
}
