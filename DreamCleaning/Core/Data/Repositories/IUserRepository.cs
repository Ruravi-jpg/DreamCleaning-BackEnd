using DC.WebApi.Core.Data.Entities;

namespace DC.WebApi.Core.Data.Repositories
{
    public interface IUserRepository : IEntityRepository<UserEntity>
    {
        Task<List<UserEntity>> GetAllAsync(CancellationToken token);
        Task<UserEntity> FindByIdAsync(long id, CancellationToken token);
        Task<UserEntity> FindByAsync(string username, CancellationToken token);
        Task<List<UserEntity>> GetAllInactiveAsync(CancellationToken token);
        Task<UserEntity> FindInactiveByIdAsync(long id, CancellationToken token);
    }
}
