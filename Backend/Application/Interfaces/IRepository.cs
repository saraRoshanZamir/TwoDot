namespace Application.Interfaces;

using System.Linq.Expressions;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    IQueryable<T> GetAll();
    IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    // Task<T> AddAsync(T entity);
    Task AddAsync(T entity);
    T Update(T entity);
    void Delete(T entity);
    public Task<int> BulkDelete(Expression<Func<T, bool>> filter);
}