namespace ToDo.DTO;

public class TaskBoardDTO
{
    public string? Name { get; set; }
    public string OwnerUsername { get; set; } = string.Empty;
    public string OwnerDisplayName { get; set; } = string.Empty;
    public int IncompletesTask { get; set; } = 0;
    public int CompletedTask { get; set; } = 0;
    public int TotalTask { get; set; } = 0;
    public string? Status { get; set; }
    public int? StatusCode { get; set; }
    public bool IsComplete { get; set; } = false;
}
