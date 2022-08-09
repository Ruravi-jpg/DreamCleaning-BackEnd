using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Domain.Models;

namespace DC.WebApi.Api.Services.Permissions
{
    public interface IUserPermissionService
    {
        public void EnsureCanModifyUser(UserEntity userToModify, UserJWT currentUser);

        public void EnsureCanCreateUser(UserCreateModel model, UserJWT currentUser);

    }
}
