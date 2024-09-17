namespace ToDo.DTO;

public class TaskItemDTO
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public int StatusCode { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? ExpireDate { get; set; }
    public bool? IsDone { get; set; } = false;
    public bool? IsExpire { get; set; } = false;
}
