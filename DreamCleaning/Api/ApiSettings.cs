using System.ComponentModel.DataAnnotations;

namespace DC.WebApi.Api
{
    public class ApiSettings
    {
        [Required, MinLength(5)]
        public string JwtSigningKey { get; set; }


        [Required, MinLength(5)]
        public string JwtIssuer { get; set; }


        [Required, MinLength(5)]
        public string JwtAudience { get; set; }


        [Range(typeof(TimeSpan), "00:05:00", "05:00:00")]
        public TimeSpan JwtExpiration { get; set; }


        [Range(typeof(TimeSpan), "00:00:00", "00:20:00")]
        public TimeSpan JwtClockSkew { get; set; } = TimeSpan.FromMinutes(2);

        public bool DoMigration { get; set; } = true;

    }
}
