using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProvaPub.Interfaces.Repository;
using ProvaPub.Models;

namespace ProvaPub.Repository;

public abstract class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : BaseEntity
{
    protected DbSet<T> DbSet { get; }
    private readonly TestDbContext _context;

    protected BaseRepository(TestDbContext dbContext)
    {
        _context = dbContext;
        DbSet = _context.Set<T>();
    }

    public virtual async Task<T?> FindByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<List<T>> GetAllPaginatedAsync(int page, int size)
    {
        return await DbSet.Skip(page * size).Take(size).ToListAsync();
    }

    public virtual async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate)
    {
        return await DbSet.Where(predicate).ToListAsync();
    }

    public virtual async Task<int> CountAsync()
    {
        return await DbSet.CountAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}