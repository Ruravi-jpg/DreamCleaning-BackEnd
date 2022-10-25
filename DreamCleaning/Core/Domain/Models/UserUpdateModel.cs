using System.ComponentModel.DataAnnotations;

namespace DC.WebApi.Core.Domain.Models
{
    public class UserUpdateModel
    {
        [StringLength(120)]
        public String Username { get; set; }
        [StringLength(120, MinimumLength = 5)]
        public string Password { get; set; }

        public UserUpdateModel()
        {

        }

        public UserUpdateModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
