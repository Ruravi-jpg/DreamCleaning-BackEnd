using Microsoft.EntityFrameworkCore.Storage;

namespace DC.WebApi.Core.Data.Repositories
{
    public interface IEntityRepository<T> where T : class
    {
        Task<int> SaveChangesAsync();
        Task AddAsync(T entity);
        void Remove(T entity);
        void Update(T entity);
        IDbContextTransaction BeginTransaction();
    }
}
