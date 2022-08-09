using DC.WebApi.Common;
using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Domain.Models;

namespace DC.WebApi.Api.Services.Permissions
{
    public class UserPermissionService : IUserPermissionService
    {
        public void EnsureCanCreateUser(UserCreateModel model, UserJWT currentUser)
        {
            //only can create users if we are superadmin
            if (currentUser.Role == UserRole.SuperAdmin)
                return;

            DCException.ThrowCannotCreateUser();
        }

        public void EnsureCanModifyUser(UserEntity userToModify, UserJWT currentUser)
        {
            //only can update users if we are superadmin
            if (currentUser.Role == UserRole.SuperAdmin)
                return;

            DCException.ThrowCannotEditUser();
        }
    }
}
