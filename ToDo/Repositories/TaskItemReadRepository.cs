using Microsoft.EntityFrameworkCore;
using ToDo.DataContexts;
using ToDo.Models;
using ToDo.Repositories.Abstracts;

namespace ToDo.Repositories;

public class TaskItemReadRepository(AppDbContext _context)
    : ReadOnlyRepositoryBase<TaskItemEntity>
{
    internal override IAsyncEnumerator<TaskItemEntity> _items => _context.TaskItems.GetAsyncEnumerator();

    public override async Task<TaskItemEntity?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.TaskItems.FirstOrDefaultAsync(i => i.Id == id, ct);
    }
}
