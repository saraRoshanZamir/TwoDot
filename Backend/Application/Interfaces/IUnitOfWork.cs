using Application.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

public interface IUnitOfWork:IDisposable
{
    IRepository<T> Repository<T>() where T : class;
    Task<int> SaveChangesAsync();
    Task<IDbContextTransaction> BeginTransactionAsync();

}