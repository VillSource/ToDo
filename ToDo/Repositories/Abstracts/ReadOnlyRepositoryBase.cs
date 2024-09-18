using ToDo.Models.Abstracts;

namespace ToDo.Repositories.Abstracts;

public abstract class ReadOnlyRepositoryBase<T> : RepositoryBase<T, int> where T : EntityBase<int> { }
public abstract class RepositoryBase<T, ID> 
    where ID : IComparable<ID>
    where T : EntityBase<ID>
{
    public abstract Task<IList<T>> ListAsync(int? take = default, CancellationToken ct = default);
    public abstract Task<T?> GetByIdAsync(ID id, CancellationToken ct = default);
}
