namespace ToDo.Models.Abstracts;

public class TraceableEntityBase : TraceableEntityBase<int> { }
public class TraceableEntityBase<T> : EntityBase<T>
    where T: IComparable<T>
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastUpdated { get; set; }
}
