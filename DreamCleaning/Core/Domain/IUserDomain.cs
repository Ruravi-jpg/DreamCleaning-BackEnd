using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Domain.Models;

namespace DC.WebApi.Core.Domain
{
    public interface IUserDomain
    {
        Task<List<UserEntity>> GetAllAsync(CancellationToken token);
        Task<List<UserEntity>> GetAllInactiveAsync(CancellationToken token);
        ValueTask<UserEntity> FindByIdAsync(long id, CancellationToken token);
        Task<UserEntity> FindByAsync(string username, string password, CancellationToken token);
        Task<UserEntity> CreateAsync(UserCreateModel user, long createdByUserId, CancellationToken token);
        Task<int> UpdateAsync(UserEntity userdb, UserUpdateModel user, CancellationToken token);
        Task<int> DeleteAsync(UserEntity user, CancellationToken token);
        ValueTask<UserEntity> FindInactiveByIdAsync(long id, CancellationToken token);
    }
}
