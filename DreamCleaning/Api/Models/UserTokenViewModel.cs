namespace DC.WebApi.Api.Models
{
    public class UserTokenViewModel
    {
        public string Token { get; set; }
        public DateTime TokenValidTo { get; set; }
        public string SecuredApiPath { get; set; }

        public UserTokenViewModel()
        {

        }

        public UserTokenViewModel(string token, DateTime validTo, string securedApiPath)
        {
            Token = token;
            TokenValidTo = validTo;
            SecuredApiPath = securedApiPath;
        }
    }
}
