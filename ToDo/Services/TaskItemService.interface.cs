using ToDo.DTO;

namespace ToDo.Services;

public interface ITaskItemService
{
    Task<IList<TaskItemDTO>> GetItemsAsync();
    Task<TaskItemDTO> GetItemAsync(int id);
}
