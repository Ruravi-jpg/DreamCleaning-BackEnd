using DC.WebApi.Common;
using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Domain.Models;

namespace DC.WebApi.Api.Services.Permissions
{
    public class PropertyPermissionService : IPropertyPermissionService
    {
        public void EnsureCanCreateProperty(UserJWT currentUser)
        {
            if (currentUser.Role == UserRole.SuperAdmin)
                return;

            DCException.ThrowCannotCreateProperty();
        }

        public void EnsureCanModifyProperty(UserJWT currentUser)
        {
            if (currentUser.Role == UserRole.SuperAdmin)
                return;

            DCException.ThrowCannotEditProperty();
        }
    }
}
