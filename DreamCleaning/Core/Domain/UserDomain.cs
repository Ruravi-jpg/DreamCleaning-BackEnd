using DC.WebApi.Common;
using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Data.Repositories;
using DC.WebApi.Core.Domain.Models;

namespace DC.WebApi.Core.Domain
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserRepository _repo;
        private readonly IPasswordHelper _passwordHelper;

        public UserDomain(IUserRepository repository, IPasswordHelper passwordHelp)
        {
            _repo = repository;
            _passwordHelper = passwordHelp;
        }

        public async Task<UserEntity> CreateAsync(UserCreateModel user, CancellationToken token)
        {
            var userExists = await _repo.FindByAsync(user.Username, token);

            if (userExists != default)
                DCException.ThrowCannotCreateEntityDuplicatedUsername();

            var salt = _passwordHelper.GenerateSalt();
            var pwd = _passwordHelper.GenerateHash(user.Password, salt);

            var userDb = new UserEntity(user.Username, pwd, salt, user.Role);

            await _repo.AddAsync(userDb);
            await _repo.SaveChangesAsync();

            return userDb;
        }

        public async Task<int> DeleteAsync(UserEntity user, CancellationToken token)
        {
            if (user == default)
                throw new ArgumentNullException(nameof(user));

            if (user.Role == UserRole.SuperAdmin)
                throw new InvalidOperationException("Cannot delete a super admin user");

            user.IsActive = false;

            _repo.Update(user);

            return await _repo.SaveChangesAsync();
        }

        public async Task<UserEntity> FindByAsync(string username, string password, CancellationToken token)
        {
            var user = await _repo.FindByAsync(username, token);
            if (user == default)
                return default;

            var pwd = _passwordHelper.GenerateHash(password, user.Salt);

            if (user.Password.SequenceEqual(pwd))
                return user;

            return default;
        }

        public async ValueTask<UserEntity> FindByIdAsync(long id, CancellationToken token = default)
        {
            var user = await _repo.FindByIdAsync(id, token);
            if (user == null)
                return default;

            return user;
        }

        public async ValueTask<UserEntity> FindInactiveByIdAsync(long id, CancellationToken token)
        {
            var user = await _repo.FindInactiveByIdAsync(id, token);
            if (user == null)
                return default;

            return user;
        }

        public Task<List<UserEntity>> GetAllAsync(CancellationToken token)
        {
            return _repo.GetAllAsync(token);
        }

        public Task<List<UserEntity>> GetAllInactiveAsync(CancellationToken token)
        {
            return _repo.GetAllInactiveAsync(token);
        }

        public async Task<int> UpdateAsync(UserEntity userdb, UserUpdateModel user, CancellationToken token)
        {
            if(userdb == default)
                throw new ArgumentNullException(nameof(userdb));

            if (!string.IsNullOrEmpty(user.Password))
            {
                var salt = _passwordHelper.GenerateSalt();
                var pwd = _passwordHelper.GenerateHash(user.Password, salt);

                userdb.Password = pwd;
                userdb.Salt = salt;
            }

            if (!string.IsNullOrEmpty(user.Username))
            {
                userdb.Username = user.Username;
            }

            _repo.Update(userdb);

            return await _repo.SaveChangesAsync();
        }
    }
}
