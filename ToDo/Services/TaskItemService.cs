using ToDo.DTO;
using ToDo.Repositories;
using ToDo.Utility;

namespace ToDo.Services;

public class TaskItemService(
        TaskItemReadRepository _itemReaderRepo,
        TimeMachine _timeMachine
    ) : ITaskItemService
{
    public async Task<Result<TaskItemDTO>> GetItemAsync(int id)
    {
        var item = await _itemReaderRepo.GetByIdAsync(id);

        if (item is null) return Result.NotFound();

        bool? isDone = item.Status switch
        {
            Constants.TaskItemStatus.Done => true,
            Constants.TaskItemStatus.Draft => null,
            Constants.TaskItemStatus.Abrogate => null,
            _ => false
        };
        bool? isExpire = isDone == false
            ? item.EndDate >= _timeMachine.Now()
            : null;

        return new TaskItemDTO()
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            Status = item.Status.ToString(),
            StatusCode = (int)item.Status,
            StartDate = item.StartDate,
            ExpireDate = item.EndDate,
            IsDone = isDone,
            IsExpire = isExpire
        };
    }

    public async Task<Result<IList<TaskItemDTO>>> GetItemsAsync()
    {
        var items = _itemReaderRepo.ToBlockingEnumerable().Select(i => new TaskItemDTO()
        {
            Id = i.Id,
            Title = i.Title,
            Status = i.Status.ToString(),
            StatusCode = (int)i.Status,
            IsDone = i.Status switch
            {
                Constants.TaskItemStatus.Done => true,
                Constants.TaskItemStatus.Draft => null,
                Constants.TaskItemStatus.Abrogate => null,
                _ => false
            }            
        }).ToList();

        if (items.Count == 0) return Result.NotFound();

        return items;
    }
}
