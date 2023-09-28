using ProvaPub.Interfaces.Repository;

namespace ProvaPub.Repository;

public abstract class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : BaseEntity
{
    protected TestDbContext Context { get; set; }

    protected BaseRepository(TestDbContext dbContext)
    {
        Context = dbContext;
    }

    public virtual IQueryable<T> FindAllQueryable()
    {
        return Context.Set<T>();
    }

    public virtual T? FindByIdQueryable(int id)
    {
        return Context.Set<T>().Where(i => i.Id == id).FirstOrDefault();
    }

    public void Add(T item)
    {
        Context.Set<T>().Add(item);
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}