using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUserProfiles()
    {
        return Ok("NOT IMPLEMENT!!");
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> GetUserProfile(string username)
    {
        return Ok($"GET {username} PROFILE NOT IMPLEMENT!!");
    }
}
