using DC.WebApi.Core.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DC.WebApi.Api.Controllers
{
    public abstract class DCController : ControllerBase
    {
        UserJWT _userJwt;

        protected UserJWT UserJwt { get { return GetUserJwt(); }}

        public DCController()
        {

        }

        protected UserJWT GetUserJwt()
        {
            if (_userJwt == default)
            {
                var claims = HttpContext.User.Claims;
                var sub = GetClaim(ClaimTypes.NameIdentifier, claims);
                var username = GetClaim(ClaimTypes.Name, claims);
                var role = GetClaim(ClaimTypes.Role, claims);

                long id = long.Parse(sub.Value);

                if (!Enum.TryParse(role.Value, out UserRole roleEnum))
                    roleEnum = UserRole.Employee;

                _userJwt = new UserJWT(id, username.Value, roleEnum);
            }
            return _userJwt;
        }

        static Claim GetClaim(string type, IEnumerable<Claim> claims)
        {
            var claim = claims.FirstOrDefault(x => x.Type == type);
            if (claim == default)
                throw new InvalidOperationException("Jwt does not have: " + type);

            if (string.IsNullOrEmpty(claim.Value))
                throw new InvalidOperationException("Jwt claim value is null or empty: " + type);

            return claim;
        }
    }
}
