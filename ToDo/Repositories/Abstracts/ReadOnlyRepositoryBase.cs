using System.Collections;
using ToDo.Models.Abstracts;

namespace ToDo.Repositories.Abstracts;

public abstract class ReadOnlyRepositoryBase<T> : RepositoryBase<T, int> where T : EntityBase<int> { }
public abstract class RepositoryBase<T, ID> : IAsyncEnumerable<T>
    where ID : IComparable<ID>
    where T : EntityBase<ID>
{
    internal abstract IAsyncEnumerator<T> _items { get; }

    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        => _items;

    public abstract Task<T?> GetByIdAsync(ID id, CancellationToken ct = default);
}
