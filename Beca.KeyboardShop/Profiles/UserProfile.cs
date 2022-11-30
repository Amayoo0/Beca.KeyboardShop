using AutoMapper;

namespace Beca.KeyboardShop.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile() {
            CreateMap<Entities.User, Models.UserDto>();
        }
    }
}
