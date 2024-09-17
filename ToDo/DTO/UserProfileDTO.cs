namespace ToDo.DTO;

public class UserProfileDTO
{
    public string Username { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public int? TotalBoard { get; set; }
    public int? TotalIncompleteTask { get; set; }
}
