namespace ToDo.Models.Abstracts;

public class EntityBase : EntityBase<int> { }
public class EntityBase<T> where T: IComparable<T>
{
    public T? Id { get; set; }
}
