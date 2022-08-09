using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DC.WebApi.Api
{
    public class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly ApiSettings _settings;

        public ConfigureJwtBearerOptions(IOptions<ApiSettings> settings)
        {
            _settings = settings.Value;
        }
        public void Configure(string name, JwtBearerOptions options)
        {
            if (name == JwtBearerDefaults.AuthenticationScheme)
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = _settings.JwtIssuer,
                    ValidAudience = _settings.JwtAudience,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JwtSigningKey)),
                    ClockSkew = _settings.JwtClockSkew
                };
            }
        }

        public void Configure(JwtBearerOptions options)
        {
            throw new NotImplementedException("This is not implemented");
        }
    }
}
