using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DC.WebApi.Core.Data.Entities
{

    public class UserEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [StringLength(120), Required]
        public string Username { get; set; }
        [Required]
        public UserRole Role { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }

        public bool IsActive { get; set; }

        public UserEntity()
        {

        }

        public UserEntity(string username, byte[] password, byte[] salt, UserRole role)
        {
            Username = username;
            Role = role;
            Password = password;
            Salt = salt;
            IsActive = true;

        }
    }
}
