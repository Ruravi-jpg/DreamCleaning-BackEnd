using System.ComponentModel.DataAnnotations;

namespace DC.WebApi.Core.Domain.Models
{
    public class UserUpdateModel
    {
        [StringLength(120), Required]
        public String Username { get; set; }
        [StringLength(120, MinimumLength = 12), Required]
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
