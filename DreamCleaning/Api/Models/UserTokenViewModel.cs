using DC.WebApi.Core.Data.Entities;

namespace DC.WebApi.Api.Models
{
    public class UserTokenViewModel
    {
        public string Token { get; set; }
        public DateTime TokenValidTo { get; set; }
        public string SecuredApiPath { get; set; }
        public UserViewModel UserData { get; set; }

        public UserTokenViewModel()
        {

        }

        public UserTokenViewModel(string token, DateTime validTo, string securedApiPath, UserEntity user)
        {
            Token = token;
            TokenValidTo = validTo;
            SecuredApiPath = securedApiPath;
            UserData = new UserViewModel(user);
        }
    }
}
