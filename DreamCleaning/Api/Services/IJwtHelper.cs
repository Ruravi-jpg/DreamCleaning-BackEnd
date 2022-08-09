using DC.WebApi.Api.Models;
using DC.WebApi.Core.Data.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DC.WebApi.Api.Services
{
    public interface IJwtHelper
    {
        JwtSecurityToken Generate(UserEntity userdb);
        UserTokenViewModel GetToken(UserEntity userdb);
        ClaimsPrincipal GetPrincipalFromRefreshToken(string token);
        bool ValidateDateFromToken(string token);
    }
}
