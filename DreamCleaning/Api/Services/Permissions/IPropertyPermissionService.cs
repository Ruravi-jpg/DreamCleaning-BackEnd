using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Domain.Models;

namespace DC.WebApi.Api.Services.Permissions
{
    public interface IPropertyPermissionService
    {
        public void EnsureCanModifyProperty(UserJWT currentUser);

        public void EnsureCanCreateProperty(UserJWT currentUser);
    }
}
