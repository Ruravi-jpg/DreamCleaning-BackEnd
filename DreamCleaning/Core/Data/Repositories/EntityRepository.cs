using DC.WebApi.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql;

namespace DC.WebApi.Core.Data.Repositories
{
    public abstract class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        protected readonly DCDbContext _context;
        private readonly DbSet<T> _collection;

        public EntityRepository(DCDbContext context, DbSet<T> collection)
        {
            _context = context;
            _collection = collection;
        }

        public virtual async Task AddAsync(T entity)
        {
            await _collection.AddAsync(entity, CancellationToken.None);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Remove(T entity)
        {
            _collection.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if (e.GetBaseException() is PostgresException pgEx)
                    if (pgEx.SqlState == PostgresErrorCodes.UniqueViolation)
                        DCException.ThrowCannotCreateEntityDuplicatedData();
                throw;
            }
        }

        public void Update(T entity)
        {
            _collection.Update(entity);
        }
    }
}
