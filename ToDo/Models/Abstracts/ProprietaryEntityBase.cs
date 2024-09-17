namespace ToDo.Models.Abstracts;

public class ProprietaryEntityBase : ProprietaryEntityBase<int> { }
public class ProprietaryEntityBase<T> : TraceableEntityBase<T>
    where T: IComparable<T>
{
    public T? CreatedBy { get; set; }
    public T? LastUpdatedBy { get; set; }
}
