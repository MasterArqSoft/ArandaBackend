using CodeFirst.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> ProductRepositoryAsync { get; }
        Task BeginTransactionAsync();

        Task CommitAsync();

        Task RollbackAsync();
    }
}