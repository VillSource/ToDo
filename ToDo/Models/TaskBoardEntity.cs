using ToDo.Constants;
using ToDo.Models.Abstracts;

namespace ToDo.Models;

public class TaskBoardEntity : ProprietaryEntityBase 
{
    public string? Name { get; set; }
    public TaskBoardStatus Status { get; set; } = TaskBoardStatus.Open;

    public IList<TaskItemEntity>? Tasks { get; set; }
}
