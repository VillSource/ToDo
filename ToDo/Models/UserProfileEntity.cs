using ToDo.Models.Abstracts;

namespace ToDo.Models;

public class UserProfileEntity : TraceableEntityBase
{
    public string? Username { get; set; }
    public string? DisplayName { get; set; }

    public IList<TaskBoardEntity>? TaskBoards { get; set; }
}
