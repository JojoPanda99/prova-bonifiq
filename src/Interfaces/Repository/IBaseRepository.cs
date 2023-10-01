using System.Linq.Expressions;
using ProvaPub.Models;

namespace ProvaPub.Interfaces.Repository;

public interface IBaseRepository<T> : IDisposable where T : BaseEntity
{
    Task<T?> FindByIdAsync(int id);
    Task<List<T>> GetAllPaginatedAsync(int page, int size);
    Task<int> CountAsync();
    Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate);
}