using Microsoft.EntityFrameworkCore;
using ToDo.DataContexts;
using ToDo.Models;

namespace ToDo.Repositories;

public class TaskItemReadRepository(AppDbContext context) : TaskItemReadRepositoryBase
{

    public override async Task<IList<TaskItemEntity>> ListAsync(int? take = default, CancellationToken ct = default){
        if (take.HasValue)
            return await context.TaskItems.Take(take.Value).ToListAsync(ct);
        return await context.TaskItems.ToListAsync(ct);
    }

    public override async Task<TaskItemEntity?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await context.TaskItems.FirstOrDefaultAsync(i => i.Id == id, ct);
    }
}
