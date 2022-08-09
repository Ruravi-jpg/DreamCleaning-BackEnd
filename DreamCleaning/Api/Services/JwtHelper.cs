using DC.WebApi.Api.Models;
using DC.WebApi.Core.Data.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DC.WebApi.Api.Services
{
    public class JwtHelper : IJwtHelper
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly TimeSpan _expiration;
        private readonly string _signingKey;


        private readonly SymmetricSecurityKey _key;
        private readonly SigningCredentials _credentials;
        readonly JwtSecurityTokenHandler _tokenHandler = new();

        public JwtHelper(IOptions<ApiSettings> settings)
        {
            _issuer = settings.Value.JwtIssuer;
            _audience = settings.Value.JwtAudience;
            _expiration = settings.Value.JwtExpiration;

            _signingKey = settings.Value.JwtSigningKey;

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Value.JwtSigningKey));
            _credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
        }
        public JwtSecurityToken Generate(UserEntity userdb)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, userdb.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, userdb.Username),
                new Claim(Constants.JwtRoleName, userdb.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            var jwt = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.Add(_expiration),
                _credentials
                );

            return jwt;
        }

        public ClaimsPrincipal GetPrincipalFromRefreshToken(string token)
        {
            throw new NotImplementedException();
        }

        public UserTokenViewModel GetToken(UserEntity userdb)
        {
            var token = Generate(userdb);
            var strToken = _tokenHandler.WriteToken(token);

            return new UserTokenViewModel(strToken, token.ValidTo, Constants.SecuredApiPath);
        }

        public bool ValidateDateFromToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
