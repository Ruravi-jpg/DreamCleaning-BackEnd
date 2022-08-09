using DC.WebApi.Core.Data.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DC.WebApi.Api.Models
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public UserRole Role { get; set; }

        public UserViewModel()
        {

        }

        public UserViewModel(UserEntity user)
        {
            Id = user.Id;
            Username = user.Username;
            Role = user.Role;
        }

        public static List<UserViewModel> FromList(IReadOnlyList<UserEntity> users)
        {
            var list = new List<UserViewModel>(users.Count);
            foreach (var user in users)
                list.Add(new UserViewModel(user));
            return list;
        }

    }
}
