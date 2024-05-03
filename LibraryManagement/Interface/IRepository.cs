using System.Linq.Expressions;

namespace LibraryManagement.Interface
{
    public interface IRepository<T> where T : class 
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<T> Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        Task<bool> Any(Expression<Func<T, bool>> filter);
        Task Add(T entity);
        void Delete(T entity);
    }
}
