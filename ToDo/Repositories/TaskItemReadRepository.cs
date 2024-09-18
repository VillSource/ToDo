using Microsoft.EntityFrameworkCore;
using ToDo.DataContexts;
using ToDo.Models;
using ToDo.Repositories.Abstracts;

namespace ToDo.Repositories;

public class TaskItemReadRepository : ReadOnlyRepositoryBase<TaskItemEntity>
{
    private readonly AppDbContext _context;

    public TaskItemReadRepository(){}
    public TaskItemReadRepository(AppDbContext context){
        _context = context;
    }
    internal override IAsyncEnumerator<TaskItemEntity> _items => _context.TaskItems.GetAsyncEnumerator();

    public async Task<IList<TaskItemEntity>> ListAsync(int? take = default, CancellationToken ct = default){
        if (take.HasValue)
            return await _context.TaskItems.Take(take.Value).ToListAsync(ct);
        return await _context.TaskItems.ToListAsync(ct);
    }

    public override async Task<TaskItemEntity?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.TaskItems.FirstOrDefaultAsync(i => i.Id == id, ct);
    }
}
