namespace ProvaPub.Interfaces.Repository;

public interface IBaseRepository<T> : IDisposable where T : BaseEntity
{
    public IQueryable<T> FindAllQueryable();
    public T? FindByIdQueryable(int id);
    public void Add(T item);
}