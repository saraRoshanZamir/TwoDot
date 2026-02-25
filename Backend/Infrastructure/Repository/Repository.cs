using System.Linq.Expressions;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _dbContext;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public IQueryable<T> GetAll()
    {
        return _dbContext.Set<T>();
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _dbContext.Set<T>().Where(predicate);
    }

    public async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
    }

    public T Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        return entity;
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public async Task<int> BulkDelete(Expression<Func<T, bool>> filter)
    {
        return await _dbContext.Set<T>().Where(filter).ExecuteUpdateAsync(e => e
            .SetProperty(x => EF.Property<bool>(x, "IsDeleted"), true)
            .SetProperty(x => EF.Property<bool>(x, "IsAvailable"), false)
            .SetProperty(x => EF.Property<DateTime>(x, "UpdatedAt"), DateTime.Now)
        );

    }
}