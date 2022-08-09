using DC.WebApi.Core.Data.Entities;

namespace DC.WebApi.Api
{
    public class UserJWT
    {
        public long Id { get; protected set; }
        public string Username { get; protected set; }
        public UserRole Role { get; protected set; }

        public UserJWT(long id, string username, UserRole role)
        {
            Id = id;
            Username = username;
            Role = role;
        }
    }

   
}
