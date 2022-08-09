using DC.WebApi.Core.Data.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace DC.WebApi.Core.Domain.Models
{
    public class UserCreateModel
    {
        [StringLength(120), Required]
        public String Username { get; set; }
        [StringLength(120, MinimumLength = 12) ,Required]
        public string Password { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public UserRole Role { get; set; }

        public UserCreateModel()
        {

        }

        public UserCreateModel(string username, string password, UserRole role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

    }
}
