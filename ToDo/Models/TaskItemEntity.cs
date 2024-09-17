using ToDo.Constants;
using ToDo.Models.Abstracts;

namespace ToDo.Models;

public class TaskItemEntity : TraceableEntityBase
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public TaskItemStatus Status { get; set; } = TaskItemStatus.Draft;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public int TaskBoardId { get; set; }
    public TaskBoardEntity? Taskboard { get; set; }

    public int? ParrentTaskId { get; set; }
    public IList<TaskItemEntity>? SubTasks { get; set; }
}
