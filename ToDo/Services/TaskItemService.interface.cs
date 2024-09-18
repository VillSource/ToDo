using ToDo.DTO;
using ToDo.Utility;

namespace ToDo.Services;

public interface ITaskItemService
{
    Task<Result<IList<TaskItemDTO>>> GetItemsAsync(CancellationToken ct = default);
    Task<Result<TaskItemDTO>> GetItemAsync(int id, CancellationToken ct = default);
}
